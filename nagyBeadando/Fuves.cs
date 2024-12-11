using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando
{
    public class Fuves : Palya
    {
        public Fuves(int sorszam, bool fedett) : base(sorszam, "füves", fedett) { }

        public override int Dij()
        {
            return 5000;
        }

    }
}
