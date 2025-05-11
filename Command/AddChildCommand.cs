using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.Command
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly LightNode _child;

        public AddChildCommand(LightElementNode element, LightNode child)
        {
            _element = element;
            _child = child;
        }

        public void Execute()
        {
            _element.AddChild(_child);
        }
    }
}
