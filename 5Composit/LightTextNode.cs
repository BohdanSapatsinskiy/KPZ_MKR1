using KPZ_MKR1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public override void Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHTML()
        {
            return Text;
        }

        public override string InnerHTML()
        {
            return Text;
        }
    }
}
