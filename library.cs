using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Rectangle
    {
        public int width {get; set;}
        public int length {get; set;}   
    }

    public class Mock
    {
        public static LinkedList<Rectangle> figures = new LinkedList<Rectangle>();

        public static void AddRectangles()
        {
            figures.Add(new Rectangle {width = 1, length = 8});
            figures.Add(new Rectangle {width = 2, length = 7});
            figures.Add(new Rectangle {width = 3, length = 3});
            figures.Add(new Rectangle {width = 4, length = 9});
            figures.Add(new Rectangle {width = 5, length = 12});
        }
    }
}