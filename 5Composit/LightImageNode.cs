using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    public class LightImageNode : LightNode
    {
        public string Src { get; }
        public string Alt { get; }

        public LightImageNode(string src, string alt = "")
        {
            Src = src;
            Alt = alt;
        }

        public override string OuterHTML()
        {
            string imageSource = IsValidUrl(Src) ? Src : GetLocalImagePath(Src);
            return $"<img src=\"{imageSource}\" alt=\"{Alt}\" />";
        }

        public override string InnerHTML()
        {
            return "";
        }

        private bool IsValidUrl(string src)
        {
            Uri uriResult;
            return Uri.TryCreate(src, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private string GetLocalImagePath(string src)
        {
            return $"file:///{src}";
        }
    }
}
