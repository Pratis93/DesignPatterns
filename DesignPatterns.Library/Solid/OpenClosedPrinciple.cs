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

            public Product(string name, ColorType color, SizeType size)
            {
                Name = name;
                Color = color;
                Size = size;
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

        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second;


            

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
                this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
            }

            public bool IsSatisfied(Product p)
            {
                return first.IsSatisfied(p) && second.IsSatisfied(p);
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
