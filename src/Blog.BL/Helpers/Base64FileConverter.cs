using System;

namespace Blog.BL.Helpers
{
    public class Base64FileConverter : IBase64FileConverter
    {
        public bool CanConvert(Type objectType) =>  objectType == typeof(string);

        public byte[] Read(object encodedFile) => Convert.FromBase64String(encodedFile as string);
    }
}
