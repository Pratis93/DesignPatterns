
using DesignPatterns.Library.Solid;
using static System.Console;
using DesignPatterns.Library.Enums;


namespace DesignPatterns.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new OpenClosedPrinciple.Product("Apple", ColorType.Green, SizeType.Small);
            var tree = new OpenClosedPrinciple.Product("Tree", ColorType.Green, SizeType.Large);
            var house = new OpenClosedPrinciple.Product("House", ColorType.Blue, SizeType.Large);





           OpenClosedPrinciple.Product[] products = { apple, tree, house };

            var bf = new OpenClosedPrinciple.BetterFilter();
            WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new OpenClosedPrinciple.ColorSpecification(ColorType.Green)))
                WriteLine($" - {p.Name} is green");

            WriteLine("Large products");
            foreach (var p in bf.Filter(products, new OpenClosedPrinciple.SizeSpecification(SizeType.Large)))
                WriteLine($" - {p.Name} is large");

            WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
              new OpenClosedPrinciple.AndSpecification<OpenClosedPrinciple.Product>(new OpenClosedPrinciple.ColorSpecification(ColorType.Blue), new OpenClosedPrinciple.SizeSpecification(SizeType.Large)))
            )
            {
                WriteLine($" - {p.Name} is big and blue");
                var a = ReadLine();
            }
        }
    }
}
