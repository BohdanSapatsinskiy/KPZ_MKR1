using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.Command
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _cssClass;

        public AddClassCommand(LightElementNode element, string cssClass)
        {
            _element = element;
            _cssClass = cssClass;
        }

        public void Execute()
        {
            _element.AddClass(_cssClass);
        }
    }
}
