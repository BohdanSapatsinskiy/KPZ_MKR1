using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.Visitor
{
    public class ElementCounter : INodeVisitor
    {
        public int Count { get; private set; }

        public void Visit(LightElementNode element)
        {
            Count++;
            foreach (var child in element.Children)
            {
                child.Accept(this);
            }
        }

        public void Visit(LightTextNode textNode)
        {
            Count++;
        }

        public void Visit(LightImageNode imageNode)
        {
            Count++;
        }
    }
}
