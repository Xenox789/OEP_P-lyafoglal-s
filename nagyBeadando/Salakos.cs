using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando
{
    public class Salakos : Palya
    {
        public Salakos(int sorszam, bool fedett) : base(sorszam, "salakos", fedett) { }

        public override int Dij()
        {
            return 3000;
        }
    }
}
