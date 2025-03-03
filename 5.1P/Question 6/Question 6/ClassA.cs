using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_6
{
    public class ClassA
    {
        public int i = 10;

        public int Sum(int j)
        {
            return i + j;
        }
        public int Product(int j)
        {
            return i * j;
        }
        public virtual double Division(int j)
        {
            return i / j;
        }

    }
}
