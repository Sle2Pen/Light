using LightApplication.LightChatsRequests;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Light.DataTemplateSelectors
{
    public class MessagePreviewSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate PhotoTemplate { get; set; }
        public DataTemplate DocumentTemplate { get; set; }
        public DataTemplate UnknownTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is TextContent)
            {
                return TextTemplate;
            }

            if(item is PhotoContent)
            {
                return PhotoTemplate;
            }

            if(item is DocumentContent)
            {
                return DocumentTemplate;
            }

            return UnknownTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
}
