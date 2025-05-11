using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    public abstract class LightNode
    {
        // Хуки життєвого циклу
        public virtual void OnCreated() { }
        public virtual void OnInserted() { }
        public virtual void OnRemoved() { }
        public virtual void OnStylesApplied() { }
        public virtual void OnClassListApplied() { }
        public virtual void OnTextRendered() { }


        public void Initialize()
        {
            OnCreated();  
            OnInserted(); 
        }


        public abstract string OuterHTML();
        public abstract string InnerHTML();
    }

}
