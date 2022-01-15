using System;

namespace Blog.BL.Helpers
{
    public interface IBase64FileConverter
    {
        public bool CanConvert(Type objectType);

        public byte[] Read(object encodedFile);

        public string Write(byte[] file);
    }
}
