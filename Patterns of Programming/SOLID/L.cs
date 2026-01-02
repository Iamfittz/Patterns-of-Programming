using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_of_Programming.SOLID
{
    internal class L
    {
        /// <summary>
        /// Liskov Substitution Principle (Принцип подстановки Лисков)
        /// 
        /// Объекты базового класса должны быть заменяемы объектами наследников
        /// без изменения корректности программы.
        /// 
        /// Если функция принимает Rectangle, она должна работать и с Square.
        /// 
        /// Плохо: Square наследует Rectangle
        ///    - Квадрат переопределяет Width/Height чтобы стороны были равны
        ///    - Но код, который меняет Width и Height отдельно, сломается:
        ///      rect.Width = 5;
        ///      rect.Height = 10;
        ///      Area ожидаем 50, а получим 100 (потому что Square сделал обе стороны = 10)
        /// 
        /// Хорошо: не наследовать Square от Rectangle
        ///    - Либо общий интерфейс IShape с методом Area
        ///    - Либо отдельные независимые классы
        /// 
        /// Зачем: наследование должно сохранять поведение, а не ломать его
        /// </summary>
    }
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle()
        {
            
        }
        public Rectangle(int width, int height)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Area => Width * Height;
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }
    //bad practice
    public class Square : Rectangle
    {
        public Square(int side)
        {
            base.Width = base.Height = side; 
        }
        //1st Fix. => public new int Height and public new int Width . New!
        public new int Height 
        {
            set { base.Width = base.Height = value; }
        }
        public new int Width 
        {
            set { Width = Height = value; }
        }
    }

}
