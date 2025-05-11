using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    using System;
    using System.Collections.Generic;

    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public bool IsBlock { get; }
        public bool IsSelfClosing { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        private Dictionary<string, Action> EventListeners { get; } = new Dictionary<string, Action>();

        public LightElementNode(string tagName, bool isBlock, bool isSelfClosing)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
        }

        public void AddClass(string cssClass)
        {
            CssClasses.Add(cssClass);
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }

        public void AddEventListener(string eventName, Action callback)
        {
            if (!EventListeners.ContainsKey(eventName))
            {
                EventListeners[eventName] = callback;
            }
            else
            {
                EventListeners[eventName] += callback;
            }
        }

        public void TriggerEvent(string eventName)
        {
            if (EventListeners.ContainsKey(eventName))
            {
                EventListeners[eventName]?.Invoke();
            }
        }

        public override string OuterHTML()
        {
            string cssClassAttribute = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
            string innerHtml = InnerHTML();

            if (IsSelfClosing)
            {
                return $"<{TagName}{cssClassAttribute} />";
            }

            return $"<{TagName}{cssClassAttribute}>{innerHtml}</{TagName}>";
        }

        public override string InnerHTML()
        {
            List<string> innerContent = new List<string>();

            foreach (var child in Children)
            {
                innerContent.Add(child.OuterHTML());
            }

            return string.Join("", innerContent);
        }
    }
}

