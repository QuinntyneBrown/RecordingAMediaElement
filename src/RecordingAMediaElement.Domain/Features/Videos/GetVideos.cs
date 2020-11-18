using MediatR;
using Microsoft.EntityFrameworkCore;
using RecordingAMediaElement.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecordingAMediaElement.Domain.Features.Videos
{
    public class GetVideos
    {
        public class Request : IRequest<Response> {  }

        public class Response
        {
            public List<VideoDto> Videos { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRecordingAMediaElementDbContext _context;

            public Handler(IRecordingAMediaElementDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    Videos = await _context.Videos.Select(x => x.ToDto()).ToListAsync()
                };
            }
        }
    }
}
