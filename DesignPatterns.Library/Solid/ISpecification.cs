using DesignPatterns.Library.Solid;

namespace DesignPatterns.Library.Solid
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(OpenClosedPrinciple.Product p);
    }
}
