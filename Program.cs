using KPZ_MKR1.Command;
using static KPZ_MKR1.LightElementNode;

namespace KPZ_MKR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Завдання 5");

            var h1Node = new LightElementNode("h1", false, false);
            h1Node.AddClass("tittle");

            var h1Text = new LightTextNode("Купити:");
            h1Node.AddChild(h1Text);

            var divNode = new LightElementNode("div", true, false);
            divNode.AddClass("block");

            List<string> products = new List<string> { "Молоко", "М'ясо", "Сир" };

            foreach (var product in products)
            {
                var productNode = new LightElementNode("p", false, false);
                productNode.AddClass("item");
                var productText = new LightTextNode(product);
                productNode.AddChild(productText);

                divNode.AddChild(productNode);
            }

            var imageNode1 = new LightImageNode("https://image.jpg", "Зображення з мережі");
            var imageNode2 = new LightImageNode("images/local_image.jpg", "Локальне зображення");

            h1Node.AddEventListener("click", () => Console.WriteLine("Заголовок натиснуто!"));
            divNode.AddEventListener("mouseover", () => Console.WriteLine("Наведено на блок!"));

            Console.WriteLine(h1Node.OuterHTML());
            Console.WriteLine(divNode.OuterHTML());
            Console.WriteLine(imageNode1.OuterHTML());
            Console.WriteLine(imageNode2.OuterHTML());

            // Тестуємо події
            Console.WriteLine("\nТестування подій:");
            h1Node.TriggerEvent("click");
            divNode.TriggerEvent("mouseover");



            Console.WriteLine("\nОбхід в глибину:");
            var dfs = divNode.GetIterator(TraversalType.DepthFirst);
            while (dfs.HasNext())
            {
                var node = dfs.Next();
                Console.WriteLine($"- {node.OuterHTML()}");
            }

            Console.WriteLine("\nОбхід в ширину:");
            var bfs = divNode.GetIterator(TraversalType.BreadthFirst);
            while (bfs.HasNext())
            {
                var node = bfs.Next();
                Console.WriteLine($"- {node.OuterHTML()}");
            }

            // Тестування хуків життєвого циклу
            Console.WriteLine("\nТестування хуків життєвого циклу:");
            h1Node.OnCreated();    
            h1Node.OnInserted();   
            divNode.OnCreated();   
            divNode.OnInserted();

            h1Node.OnStylesApplied();    
            h1Node.OnClassListApplied(); 
            divNode.OnStylesApplied();
            divNode.OnClassListApplied();


            Console.WriteLine("\nТестування команд:");
            var newh1Node = new LightElementNode("h1", false, false);
            var addClassCommand = new AddClassCommand(newh1Node, "tittle");
            var addChildCommand = new AddChildCommand(newh1Node, new LightTextNode("Hello World"));

            var invoker = new CommandInvoker();
            invoker.StoreAndExecute(addClassCommand);
            invoker.StoreAndExecute(addChildCommand);
            Console.WriteLine(newh1Node.OuterHTML());
        }
    }
}
