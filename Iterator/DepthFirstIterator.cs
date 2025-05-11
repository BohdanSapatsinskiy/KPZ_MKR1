using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.Iterator
{
    public class DepthFirstIterator : ILightNodeIterator
    {
        private readonly Stack<LightNode> stack = new Stack<LightNode>();

        public DepthFirstIterator(LightNode root)
        {
            if (root != null)
                stack.Push(root);
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public LightNode Next()
        {
            var current = stack.Pop();

            if (current is LightElementNode elementNode)
            {
                for (int i = elementNode.Children.Count - 1; i >= 0; i--)
                {
                    stack.Push(elementNode.Children[i]);
                }
            }

            return current;
        }
    }
}
