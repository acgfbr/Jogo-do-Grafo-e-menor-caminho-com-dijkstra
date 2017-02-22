using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace grafinho_1
{
    public class vertice
    {
        public vertice(Point point, int _id)
        {
            p = point;
            id = _id;
        }

        public Point p { get; private set; }
        public int id { get; private set; }
        public int distancia { get; set; }
    }
}
