using FluentValidation;
using MediatR;
using RecordingAMediaElement.Core.Data;
using RecordingAMediaElement.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RecordingAMediaElement.Domain.Features.Videos
{
    public class UpsertVideo
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Video).NotNull();
                RuleFor(request => request.Video).SetValidator(new VideoValidator());
            }
        }

        public class Request : IRequest<Response> {  
            public VideoDto Video { get; set; }
        }

        public class Response
        {
            public VideoDto Video { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRecordingAMediaElementDbContext _context;

            public Handler(IRecordingAMediaElementDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var video = await _context.Videos.FindAsync(request.Video.VideoId);

                if (video == null)
                {
                    video = new Video();
                    await _context.Videos.AddAsync(video);
                }

                video.VideoId = request.Video.VideoId;
                video.Name = request.Video.Name;
                video.DigitalAssetId = request.Video.DigitalAssetId;

                await _context.SaveChangesAsync(cancellationToken);

			    return new Response() { 
                    Video = video.ToDto()
                };
            }
        }
    }
}
