using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.LightChatsRequests
{
    public class TextContent
    {
        public string Text { get; set; }
        public IEnumerable<FormattedFragmentDescriptor> TableOfFragments { get; set; }
    }

    public class FormattedFragmentDescriptor
    {
        public FormatType Format { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }

    public enum FormatType
    {
        Mention,
        Hashtag,
        Bold,
        Italic,
        Url,
        Email,
        Phone,
        Code,
        Pre,
        TextUrl
    };
}
