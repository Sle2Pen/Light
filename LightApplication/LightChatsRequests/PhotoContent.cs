using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.LightChatsRequests
{
    public class PhotoContent
    {
        public IEnumerable<PhotoSizeDescriptor> Photos { get; set; }
        public bool HasMiniature { get; set; }
        public Miniature Miniature { get; set; }
        public bool IsSecret { get; set; }
        public TextContent Caption { get; set; }
    }

    public class PhotoSizeDescriptor
    {
        public PhotoSizeType SizeType { get; set; } 
        public int Width { get; set; }
        public int Height { get; set; }

        //photo = file { ... }  // ⚠️ может быть null
    }

    public enum PhotoSizeType
    {
        Thumbnail,
        Small,
        Medium,
        Large,
        ExtraLarge,
        Full
    };

    //public enum MiniatureFormat
    //{
    //    Jpeg,
    //    Png,
    //    Gif
    //}
    public class Miniature
    {
        //public MiniatureFormat MiniatureFormat { get; set; }
        public byte[] Data { get; set; }
    }
}
