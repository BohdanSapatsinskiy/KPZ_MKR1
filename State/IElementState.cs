using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.State
{
    public interface IElementState
    {
        void Render(LightElementNode element);
    }
}
