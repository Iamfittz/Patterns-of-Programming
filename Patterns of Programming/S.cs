using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_of_Programming
{
    internal class S
    {
    }
    public class Journal
    {
        private readonly List<string> entries
            = new List<string>();

        public void AddEntry(string text)
        {
            entries.Add(text);
        }
        public void RemoveEntry(int index)
        {
            if (index < entries.Count && index >= 0)
            {
                entries.RemoveAt(index);
            }
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        public void Load(string filename) { }
        public void Load(Uri uri) { }
    }

    public class PersistanceManager
    {
        private void Verify(string filename) { }
        public void Save(Journal journal, string filename, bool overwrite = false)
        {
            Verify(filename);
            File.WriteAllText(filename, journal.ToString());
        }
    }

}
