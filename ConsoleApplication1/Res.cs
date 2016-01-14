using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Res
    {
        public int Pos;
        public int Neg;
        public int Neu;

        public Res()
        {
            Pos = 0;
            Neg = 0;
            Neu = 0;
        }

        public int Totale
        {
            get { return Pos + Neg; }
            private set { }
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3}", Pos, Neg, Neu, Totale);
        }
    }
}
