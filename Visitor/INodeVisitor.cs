using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.Visitor
{
    public interface INodeVisitor
    {
        void Visit(LightElementNode element);
        void Visit(LightTextNode textNode);
        void Visit(LightImageNode imageNode);
    }
}
