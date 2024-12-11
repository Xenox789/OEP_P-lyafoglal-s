using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando
{
    public class Palya
    {
        public int sorszam;
        public string tipus;
        public bool fedett;
        public List<Foglalas> foglalasok = new List<Foglalas>();

        public Palya(int sorszam, string tipus, bool fedett)
        { 
            this.sorszam = sorszam; 
            this.tipus = tipus;
            this.fedett = fedett;        
        }

        public bool vanFoglalas(DateOnly datum, int ora)
        {
            return foglalasok.Any(f => f.datum == datum && f.ora == ora);
        }

        public Foglalas getFoglalás(DateOnly datum, int ora)
        {
            if (!foglalasok.Any(f => f.datum == datum && f.ora == ora)) 
            {
                throw new Exception("Nem található ilyen foglalás.");
            }
            else
            {
                return foglalasok.Find(f => f.datum == datum && f.ora == ora);
            }
                
        }

        public void FoglalasHozzadasa(Foglalas foglalas)
        {
            foglalasok.Add(foglalas);
        }

        public void FoglalasTorlese(Foglalas foglalas)
        {
            foglalasok.Remove(foglalas);
        }
        public virtual int Dij()
        {
            return 0;
        }

        public int OraDij()
        {
            if(fedett)
            {
                return (int)(Dij()*1.2);

            }
            else { return Dij(); }
        }



    }
}
