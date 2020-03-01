using DesignPatterns.Library.Solid;
using DesignPatterns.Library.Constants;
using DesignPatterns.Library.Enums;
using static System.Console;

namespace DesignPatterns.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int searchPrice = DesignConstant.Cost_15;

           var apple = new OpenClosedPrinciple.Product(DesignConstant.Apple, DesignConstant.Cost_5, ColorType.Green, SizeType.Small);
           var tree = new OpenClosedPrinciple.Product(DesignConstant.Tree, DesignConstant.Cost_10, ColorType.Green, SizeType.Large);
           var house = new OpenClosedPrinciple.Product(DesignConstant.Hause, DesignConstant.Cost_15, ColorType.Blue, SizeType.Large);
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
                var ab = ReadLine();
            }
            
                
                  
               
            
        }
    }
}
