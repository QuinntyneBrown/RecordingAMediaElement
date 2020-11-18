using System;

namespace RecordingAMediaElement.Domain.Features.DigitalAssets
{
    public class DigitalAssetDto
    {
        public Guid DigitalAssetId { get; set; }           
        public string Name { get; set; }        
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
    }
}
