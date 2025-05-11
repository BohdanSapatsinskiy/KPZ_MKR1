using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.State
{
    public class ActiveState : IElementState
    {
        public void Render(LightElementNode element)
        {
            Console.WriteLine($"Елемент {element.TagName} активний.");
        }
    }
}
