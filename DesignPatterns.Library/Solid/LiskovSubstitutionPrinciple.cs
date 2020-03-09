using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns.Library.Solid
{
    public class LiskovSubstitutionPrinciple
    {

        //LiskovSubstitutionPrinciple.Rectangle rc = new LiskovSubstitutionPrinciple.Rectangle(2, 3);
        //WriteLine($"{rc} has area {LiskovSubstitutionPrinciple.Area(rc)}");

        //LiskovSubstitutionPrinciple.Rectangle sq = new LiskovSubstitutionPrinciple.Square(4);
        //WriteLine($"{sq} has area {LiskovSubstitutionPrinciple.Area(sq)}");
        //ReadLine();

        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public Rectangle()
            {

            }

            public Rectangle(int width, int height)
            {
                Width = width;
                Height = height;
            }

            public override string ToString()
            {
                return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
            }
        }

        public class Square : Rectangle
        {
            public Square()
            {

            }

            public Square(int with)
            {
                base.Width = base.Height = with;
            }

            public override int Width
            {
                set { base.Width = base.Height = value; }
            }

            public override int Height
            {
                set { base.Width = base.Height = value; }
            }
        }
        static public int Area(Rectangle r) => r.Width * r.Height;
    }
}
