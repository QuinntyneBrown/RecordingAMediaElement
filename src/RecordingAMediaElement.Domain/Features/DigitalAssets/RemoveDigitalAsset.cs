using MediatR;
using RecordingAMediaElement.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecordingAMediaElement.Domain.Features.DigitalAssets
{
    public class RemoveDigitalAsset
    {
        public class Request : IRequest<Unit> {  
            public Guid DigitalAssetId { get; set; }        
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IRecordingAMediaElementDbContext _context;

            public Handler(IRecordingAMediaElementDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken) {
                
                _context.DigitalAssets.Remove(await _context.DigitalAssets.FindAsync(request.DigitalAssetId));
                
                await _context.SaveChangesAsync(cancellationToken);			    
                
                return new Unit();
            }
        }
    }
}
