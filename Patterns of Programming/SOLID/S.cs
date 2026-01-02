using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_of_Programming.SOLID
{
    internal class S
    {
        /// <summary>
        /// Single Responsibility Principle (Принцип единственной ответственности)
        /// 
        /// Каждый класс должен иметь только одну причину для изменения.
        /// Класс должен отвечать за что-то одно.
        /// 
        /// Пример:
        ///     Journal — управляет только записями (добавление, удаление, отображение)
        ///     PersistanceManager — отвечает только за сохранение в файл
        /// 
        ///     Плохо: методы Load внутри Journal нарушают SRP,
        ///     потому что класс начинает отвечать ещё и за загрузку/сохранение
        /// 
        ///     Хорошо: вынести работу с файлами в отдельный класс (PersistanceManager)
        /// 
        /// Зачем: упрощает тестирование, уменьшает связность, 
        /// изменения в одной области не ломают другую
        /// </summary>
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
