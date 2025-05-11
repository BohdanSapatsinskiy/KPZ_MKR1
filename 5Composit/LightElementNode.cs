using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_MKR1
{
    using KPZ_MKR1.Iterator;
    using KPZ_MKR1.State;
    using KPZ_MKR1.Visitor;
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
        public IElementState CurrentState { get; set; }

        public override void Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }


        public LightElementNode(string tagName, bool isBlock, bool isSelfClosing)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            Children = new List<LightNode>();

            Initialize();

            CurrentState = new InactiveState();
        }

        //Перевірка стану
        public void Render()
        {
            CurrentState.Render(this);
        }

        public void AddClass(string cssClass)
        {
            CssClasses.Add(cssClass);

            OnClassListApplied();
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);

            OnInserted();
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

        
        
        
        //Отримання ітераторів
        public enum TraversalType
        {
            DepthFirst,
            BreadthFirst
        }

        public ILightNodeIterator GetIterator(TraversalType type)
        {
            return type switch
            {
                TraversalType.DepthFirst => new DepthFirstIterator(this),
                TraversalType.BreadthFirst => new BreadthFirstIterator(this),
                _ => throw new ArgumentException("Unknown traversal type")
            };
        }



        // Хуки життєвого циклу
        public override void OnCreated()
        {
            Console.WriteLine($"Елемент {TagName} створений.");
        }

        public override void OnInserted()
        {
            Console.WriteLine($"Елемент {TagName} вставлений в дерево.");
        }

        public override void OnRemoved()
        {
            Console.WriteLine($"Елемент {TagName} видалений.");
        }

        public override void OnStylesApplied()
        {
            Console.WriteLine($"Стилі застосовані до {TagName}.");
        }

        public override void OnClassListApplied()
        {
            Console.WriteLine($"Класи застосовані до {TagName}: {string.Join(", ", CssClasses)}.");
        }

        public override void OnTextRendered()
        {
            Console.WriteLine($"Текст відрендерено для {TagName}.");
        }
    }
}

