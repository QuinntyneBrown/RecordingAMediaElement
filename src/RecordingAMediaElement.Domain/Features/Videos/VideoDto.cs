using System;

namespace RecordingAMediaElement.Domain.Features.Videos
{
    public class VideoDto
    {
        public Guid VideoId { get; set; }
        public string Name { get; set; }
        public Guid DigitalAssetId { get; set; }
    }
}
