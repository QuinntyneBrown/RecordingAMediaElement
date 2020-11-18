using MediatR;
using RecordingAMediaElement.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecordingAMediaElement.Domain.Features.Videos
{
    public class RemoveVideo
    {
        public class Request : IRequest<Unit> {  
            public Guid VideoId { get; set; }        
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IRecordingAMediaElementDbContext _context;

            public Handler(IRecordingAMediaElementDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {
                
                _context.Videos.Remove(await _context.Videos.FindAsync(request.VideoId));
                
                await _context.SaveChangesAsync(cancellationToken);			    
                
                return new Unit();
            }
        }
    }
}
