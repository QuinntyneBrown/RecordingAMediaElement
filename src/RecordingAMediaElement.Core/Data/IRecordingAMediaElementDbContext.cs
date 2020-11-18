using Microsoft.EntityFrameworkCore;
using RecordingAMediaElement.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RecordingAMediaElement.Core.Data
{
    public interface IRecordingAMediaElementDbContext
    {
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<Video> Videos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
