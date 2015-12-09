using Lime.Protocol;

namespace Iris.Sdk
{
    public class MediaTypes
    {
        static MediaType _any = new MediaType("*", "*");
        static MediaType _plainText = new MediaType(MediaType.DiscreteTypes.Text, MediaType.SubTypes.Plain);

        public static MediaType Any => _any;

        public static MediaType PlainText => _plainText;
    }
}