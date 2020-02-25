using DesignPatterns.Library.Solid;
using static System.Console;

namespace DesignPatterns.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new OpenClosedPrinciple.Product("Apple", OpenClosedPrinciple.Color.Green, OpenClosedPrinciple.Size.Small);
            var tree = new OpenClosedPrinciple.Product("Tree", OpenClosedPrinciple.Color.Green, OpenClosedPrinciple.Size.Large);
            var house = new OpenClosedPrinciple.Product("House", OpenClosedPrinciple.Color.Blue, OpenClosedPrinciple.Size.Large);

            OpenClosedPrinciple.Product[] products = { apple, tree, house };

            var pf = new OpenClosedPrinciple.ProductFilter();
            WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, OpenClosedPrinciple.Color.Green))
                WriteLine($" - {p.Name} is green");

            // ^^ BEFORE

            // vv AFTER
            var bf = new OpenClosedPrinciple.BetterFilter();
            WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new OpenClosedPrinciple.ColorSpecification(OpenClosedPrinciple.Color.Green)))
                WriteLine($" - {p.Name} is green");

            WriteLine("Large products");
            foreach (var p in bf.Filter(products, new OpenClosedPrinciple.SizeSpecification(OpenClosedPrinciple.Size.Large)))
                WriteLine($" - {p.Name} is large");

            WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
              new OpenClosedPrinciple.AndSpecification<OpenClosedPrinciple.Product>(new OpenClosedPrinciple.ColorSpecification(OpenClosedPrinciple.Color.Blue), new OpenClosedPrinciple.SizeSpecification(OpenClosedPrinciple.Size.Large)))
            )
            {
                WriteLine($" - {p.Name} is big and blue");
                var a = ReadLine();
            }
        }
    }
}
