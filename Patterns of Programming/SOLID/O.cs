using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_of_Programming.SOLID
{
    internal class O
    {
        /// <summary>
        /// Open-Closed Principle (Принцип открытости/закрытости)
        /// 
        /// Классы должны быть открыты для расширения, но закрыты для модификации.
        /// Новый функционал добавляется через наследование/композицию, а не изменением существующего кода.
        /// 
        /// Плохо: ProductFilter
        ///    - Каждый новый фильтр = новый метод в классе
        ///    - "State space explosion" — комбинации фильтров растут экспоненциально
        ///    - Приходится менять уже работающий (и протестированный) код
        /// 
        /// Хорошо: BetterFilter + Specification
        ///    - Фильтр написан один раз и больше не меняется
        ///    - Новые критерии = новые классы (ColorSpecification, SizeSpecification)
        ///    - Комбинации через AndSpecification (композиция)
        ///    - Легко тестировать каждую спецификацию отдельно
        /// 
        /// Паттерн: Specification Pattern
        /// Зачем: код стабильнее, меньше багов при добавлении нового функционала
        /// </summary>
    }

    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Large
    }

    public class Product
    {
        public readonly string Name;
        public readonly Color Color;
        public readonly Size Size;
        public Product(string name, Color color, Size size)
        {
            this.Name = name;
            this.Color = color;
            this.Size = size;
        }
    }
    /// <summary>
    /// Bad practice. In case you need more specific filtering, 
    /// then you must to create a new methods inside class. Therefore, testing logic and aproach might be didn't pass.
    /// </summary>
    public class ProductFilter
    {
        //state space explosion
        public IEnumerable<Product> FilterdByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }
        public IEnumerable<Product> FilterdBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                {
                    yield return p;
                }
            }
        }
    }

    /// <summary>
    /// Create Interface with T, beacause we create a common filter for every object . Not only Product
    /// Create abstarct class which defien как именно будет происходит фильтрация
    /// </summary>
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, Specification<T> spec);
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, Specification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                {
                    yield return i;
                }
            }
        }
    }

    public abstract class Specification<T>
    {
        public abstract bool IsSatisfied(T item);
    }

    public class ColorSpecification : Specification<Product>
    {
        private readonly Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public override bool IsSatisfied(Product item)
        {
            return item.Color == color;
        }
    }
    public class SizeSpecification : Specification<Product>
    {
        private readonly Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public override bool IsSatisfied(Product item)
        {
            return item.Size == size;
        }
    }
    //Combinator
    public class AndSpecification : Specification<Product>
    {
        private readonly Specification<Product> first, second;
        public AndSpecification(Specification<Product> first, Specification<Product> second)
        {
            this.first = first;
            this.second = second;
        }
        public override bool IsSatisfied(Product item)
        {
            return first.IsSatisfied(item) && second.IsSatisfied(item);   
        }
    }

}
