using RecordingAMediaElement.Core.Models;
using RecordingAMediaElement.Domain.Features.Videos;

namespace RecordingAMediaElement.Domain.Features
{
    public static class VideoExtensions
    {
        public static VideoDto ToDto(this Video video)
        {
            return new VideoDto
            {
                VideoId = video.VideoId,
                Name = video.Name,
                DigitalAssetId = video.DigitalAssetId,
            };
        }
    }
}
