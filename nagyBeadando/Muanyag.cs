using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando
{
    public class Muanyag : Palya
    {
        public Muanyag(int sorszam, bool fedett) : base(sorszam, "műanyag", fedett) { }

        public override int Dij()
        {
            return 2000;
        }
    }
}
