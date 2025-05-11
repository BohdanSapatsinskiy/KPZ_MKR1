using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1.Iterator
{
    public interface ILightNodeIterator
    {
        bool HasNext();
        LightNode Next();
    }
}
