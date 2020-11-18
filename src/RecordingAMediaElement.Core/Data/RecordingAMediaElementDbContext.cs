using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecordingAMediaElement.Core.Models;

namespace RecordingAMediaElement.Core.Data
{
    public class RecordingAMediaElementDbContext: DbContext, IRecordingAMediaElementDbContext
    {
        public RecordingAMediaElementDbContext(DbContextOptions options)
            :base(options) { }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<Video> Videos { get; private set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
