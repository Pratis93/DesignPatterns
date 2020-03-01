using System;
using System.Collections.Generic;
using DesignPatterns.Library.Enums;

namespace DesignPatterns.Library.Solid
{
    public class OpenClosedPrinciple
    {
        public class Product
        {
            public string Name;
            public ColorType Color;
            public SizeType Size;
            public int Price;

            public Product(string name, int price, ColorType color, SizeType size)
            {
                Name = name;
                Color = color;
                Size = size;
                Price = price;
            }
        }

         public class ColorSpecification : ISpecification<Product>
        {
            private ColorType color;

            public ColorSpecification(ColorType color)
            {
                this.color = color;
            }

            public bool IsSatisfied(Product p)
            {
                return p.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private SizeType size;

            public SizeSpecification(SizeType size)
            {
                this.size = size;
            }

            public bool IsSatisfied(Product p)
            {
                return p.Size == size;
            }
        }

        public class PriceSpecification : ISpecification<Product>
        {
            private int price;

            public PriceSpecification(int price)
            {
                this.price = price;
            }

            public bool IsSatisfied(Product p)
            {
                return p.Price == price;
            }
        }

        public class TreeSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second, third;

            public bool IsSatisfied(Product p)
            {
                return first.IsSatisfied(p) && second.IsSatisfied(p) && third.IsSatisfied(p);
            }


            public TreeSpecification(ISpecification<T> first, ISpecification<T> second, ISpecification<T> third)
            {
                this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
                this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
                this.third = third ?? throw new ArgumentNullException(paramName: nameof(third));
            }
        }

        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var i in items)
                    if (spec.IsSatisfied(i))
                        yield return i;

            }
        }
    }
}
