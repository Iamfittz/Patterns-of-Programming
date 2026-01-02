namespace Patterns_of_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Journal j = new Journal();
            j.AddEntry("I'm happy today");
            j.AddEntry("I'm ate a bug");
            Console.WriteLine(j);

            var p = new PersistanceManager();
            var filename = @"C:\temp\temp.txt";
            p.Save(j,filename);
        }
    }
}
