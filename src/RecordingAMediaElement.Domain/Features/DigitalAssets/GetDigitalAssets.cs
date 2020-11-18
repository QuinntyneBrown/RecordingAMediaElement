using MediatR;
using Microsoft.EntityFrameworkCore;
using RecordingAMediaElement.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecordingAMediaElement.Domain.Features.DigitalAssets
{
    public class GetDigitalAssets
    {
        public class Request : IRequest<Response> {  }

        public class Response
        {
            public List<DigitalAssetDto> DigitalAssets { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRecordingAMediaElementDbContext _context;

            public Handler(IRecordingAMediaElementDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new Response() { 
                    DigitalAssets = await _context.DigitalAssets.Select(x => x.ToDto()).ToListAsync()
                };
            }
        }
    }
}
