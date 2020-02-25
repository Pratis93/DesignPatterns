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

        public class ProductFilter
        {
            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, ColorType color)
            {
                foreach (var p in products)
                    if (p.Color == color)
                        yield return p;
            }

            public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, SizeType size)
            {
                foreach (var p in products)
                    if (p.Size == size)
                        yield return p;
            }

            public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, SizeType size, ColorType color)
            {
                foreach (var p in products)
                    if (p.Size == size && p.Color == color)
                        yield return p;
            } 
        }

        public interface ISpecification<T>
        {
            bool IsSatisfied(Product p);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
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

        // combinator
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
