using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecordingAMediaElement.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Video
    {
        [Key]
        public Guid VideoId { get; set; }
        public string Name { get; set; }
        public Guid DigitalAssetId { get; set; }
    }

}
