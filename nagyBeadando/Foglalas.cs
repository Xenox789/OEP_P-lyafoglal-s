using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando
{
    public class Foglalas
    {
        public Tag foglalo;
        public DateOnly datum;
        public int ora;
        public Palya palya;

        public Foglalas(Tag foglalo, DateOnly datum, int ora, Palya palya)
        {
            this.foglalo = foglalo;
            this.datum = datum;
            this.ora = ora;
            this.palya = palya;
        }
    }
}
