using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.Iterator
{
    public class BreadthFirstIterator : ILightNodeIterator
    {
        private readonly Queue<LightNode> queue = new Queue<LightNode>();

        public BreadthFirstIterator(LightNode root)
        {
            if (root != null)
                queue.Enqueue(root);
        }

        public bool HasNext()
        {
            return queue.Count > 0;
        }

        public LightNode Next()
        {
            var current = queue.Dequeue();

            if (current is LightElementNode elementNode)
            {
                foreach (var child in elementNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return current;
        }
    }
}
