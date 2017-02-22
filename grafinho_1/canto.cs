using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grafinho_1
{
    public class canto
    {
        public canto(int _de, int _para, double _peso)
        {
            de = _de;
            para = _para;
            peso = _peso;
        }

        public int de { get; private set; }
        public int para { get; private set; }
        public double peso { get; private set; }
    }
}
