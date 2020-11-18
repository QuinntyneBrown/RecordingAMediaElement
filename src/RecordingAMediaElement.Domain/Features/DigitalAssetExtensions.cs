using RecordingAMediaElement.Core.Models;
using RecordingAMediaElement.Domain.Features.DigitalAssets;

namespace RecordingAMediaElement.Domain.Features
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
            return new DigitalAssetDto
            {
                DigitalAssetId = digitalAsset.DigitalAssetId,
                Name = digitalAsset.Name,
                Bytes = digitalAsset.Bytes,
                ContentType = digitalAsset.ContentType,
            };
        }
    }
}
