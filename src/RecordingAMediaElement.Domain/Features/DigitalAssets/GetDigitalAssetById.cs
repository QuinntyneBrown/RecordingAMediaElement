using MediatR;
using RecordingAMediaElement.Core.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecordingAMediaElement.Domain.Features.DigitalAssets
{
    public class GetDigitalAssetById
    {
        public class Request : IRequest<Response> {  
            public Guid DigitalAssetId { get; set; }        
        }

        public class Response
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRecordingAMediaElementDbContext _context;

            public Handler(IRecordingAMediaElementDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    DigitalAsset = (await _context.DigitalAssets.FindAsync(request.DigitalAssetId)).ToDto()
                };
            }
        }
    }
}
