
using DesignPatterns.Library.Solid;
using static System.Console;
using DesignPatterns.Library.Enums;


namespace DesignPatterns.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new OpenClosedPrinciple.Product("Apple", 5, ColorType.Green, SizeType.Small);
            var tree = new OpenClosedPrinciple.Product("Tree",2, ColorType.Green, SizeType.Large);
            var house = new OpenClosedPrinciple.Product("House", 15, ColorType.Blue, SizeType.Large);

            int searchPrice = 13; 

                                 
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
              new OpenClosedPrinciple.TreeSpecification<OpenClosedPrinciple.Product>
              (new OpenClosedPrinciple.PriceSpecification(searchPrice),
              new OpenClosedPrinciple.ColorSpecification(ColorType.Blue),
              new OpenClosedPrinciple.SizeSpecification(SizeType.Large)
              )))
            {
                if (p.Name == null)
                {
                    WriteLine($"No items");
                    var a = ReadLine();
                }
                else
                {
                    WriteLine($" - {p.Name} is big and blue and cost 15");
                    var a = ReadLine();
                }
            }
        }
    }
}
