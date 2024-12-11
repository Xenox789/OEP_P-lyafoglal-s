using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nagyBeadando;

namespace nagyBeadando
{
    public class Tag
    {
        public string nev;
        public Klub klub;
        public List<Foglalas> foglalasok;

        public Tag(string nev)
        {
            this.nev = nev;
            this.foglalasok = new List<Foglalas>();
        }

        public void Belepes(Klub klub)
        {
            klub.AddTag(this);
            this.klub = klub;

        }

        public void Kilepes()
        {
            if (this.klub == null)
                throw new Exception("Ön nem tag. Elöszőr lépjen be.");
            klub.DeleteTag(this);
            
        }

        public void Foglalas(DateOnly datum, int ora, int sorszam)
        {
            if (this.klub == null)
                throw new Exception("Ön nem tag. Elöszőr lépjen be.");
            klub.FoglalasKezelese(this, sorszam, datum, ora);
        }

        public void FoglalasHozzadasa(Foglalas foglalas)
        {
            foglalasok.Add(foglalas);
        }

        public void Lemondas(DateOnly datum, int ora, int sorszam)
        {
            if (this.klub == null)
                throw new Exception("Ön nem tag. Elöszőr lépjen be.");
            klub.FoglalasLemondas(this, sorszam, datum, ora);  
        }

        public void FoglalasTorlese(Foglalas foglalas)
        {
            foglalasok.Remove(foglalas);
        }
        public void Napidij(DateOnly datum)
        {
            int osszeg = 0;

            foreach(Foglalas foglalas in foglalasok)
            {
                if(foglalas.datum == datum)
                {
                    osszeg += foglalas.palya.OraDij();
                }
            }
            Console.WriteLine("\n" + this.nev + " napidíja: " + osszeg);
        }

        public void FoglaltPalyak(DateOnly datum)
        {
            if(foglalasok.Count == 0)
            {
                Console.WriteLine("\n" + this.nev + " klubtagnak nincs aktív foglalása!");
            }
            Console.WriteLine( "\n" + this.nev + " aktív foglalásai " + datum + " napon: ");
            Console.WriteLine("----------------------------------------");
            foreach(Foglalas foglalas in foglalasok )
            {
                if(foglalas.datum == datum)
                {
                    Console.WriteLine("Óra: " + foglalas.ora);
                    Console.WriteLine("Pálya: " + foglalas.palya.sorszam);
                    Console.WriteLine("----------------------------------------");

                }
            }
        }
    }
}
