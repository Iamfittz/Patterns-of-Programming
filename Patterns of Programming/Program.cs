using Patterns_of_Programming.SOLID;
using System.Security.Cryptography.X509Certificates;

namespace Patterns_of_Programming
{
    internal class Program
    {
        public static void UseIt(Rectangle r)
        {
            int width = r.Width;
            r.Height = 10;
            //10*width
            Console.WriteLine($"Expected area of {10*width}, " +
                $"got {r.Area}");
        }
        static void Main(string[] args)
        {
            #region SingleResponsibility
            //Journal j = new Journal();
            //j.AddEntry("I'm happy today");
            //j.AddEntry("I'm ate a bug");
            //Console.WriteLine(j);

            //var p = new PersistanceManager();
            //var filename = @"C:\temp\temp.txt";
            //p.Save(j,filename);
            #endregion

            #region Open-Closed Principle

            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Large);
            //var house = new Product("House", Color.Blue, Size.Large);

            //Product[] products = { apple, tree, house };
            ////bad practice
            //var pf = new ProductFilter();
            //Console.WriteLine("Green products (bad practice):");

            //foreach (var p in pf.FilterdByColor(products, Color.Green))
            //    Console.WriteLine($" - {p.Name} is green");

            //Console.ReadLine();
            ////good Open-Closed architecture
            //var bf = new BetterFilter();
            //Console.WriteLine("Large products:");
            //var largeSpec = new SizeSpecification(Size.Large);
            //foreach (var p in bf.Filter(products,largeSpec))
            //{
            //    Console.WriteLine($" - {p.Name} is large");
            //}

            //var largeBlueSpec = new AndSpecification(largeSpec, new ColorSpecification(Color.Blue));

            //foreach (var item in bf.Filter(products, largeBlueSpec))
            //{
            //    Console.WriteLine($" - {item.Name} is large and Blue");
            //}
            #endregion

            #region Liskov Substitution Principle

            var rc = new Rectangle(3, 2);
            UseIt(rc);

            //bad practice
            var sq = new Square(5);
            UseIt(sq);
            #endregion
        }
    }
}
