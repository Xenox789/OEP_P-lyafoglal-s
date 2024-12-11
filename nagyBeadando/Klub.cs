using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace nagyBeadando
{
    public class Klub
    {
        public string nev;
        public List<Palya> palyak = new List<Palya>();
        public List<Tag> klubtagok = new List<Tag>();

        public Klub(string nev)
        {
            this.nev = nev;
        }

        public void AddPalya(string tipus, bool fedett)
        {
            int sorszam = palyak.Count + 1;
            while (sorszam > 0)
            {
                if (palyak.Any(p=> p.sorszam == sorszam))
                {
                    sorszam--;
                }
                else
                {
                    break;
                }
            }
            Palya ujpalya;
            switch (tipus)
            {
                case "füves":
                    ujpalya = new Fuves(sorszam, fedett); break;
                case "salakos":
                    ujpalya = new Salakos(sorszam, fedett); break;
                case "műanyag":
                    ujpalya = new Muanyag(sorszam, fedett); break;
                default:
                    Console.WriteLine("\nHibás pályatípus!");
                    return;
            }
            palyak.Add(ujpalya);
            Console.WriteLine("Pálya hozzáadva: " + sorszam);
        }

        public void DeletePalya(int sorszam)
        {
            Palya palya = palyak.Find(p=> p.sorszam == sorszam);
            if (palya != null)
            {
                foreach(Foglalas foglalas in palya.foglalasok)
                {
                    foglalas.foglalo.FoglalasTorlese(foglalas);
                }
                palyak.Remove(palya);
                Console.WriteLine("\nPálya törölve: " + palya.sorszam);
            }
            else
            {
                throw new Exception("\nNem található ilyen pálya!");
            }
        }

        public void AddTag(Tag tag)
        {
            if(klubtagok.Any(f=> f.nev == tag.nev))
            {
                throw new Exception ("\nEz a személy már tag.");
            }
            else
            {
                klubtagok.Add(tag);
                Console.WriteLine("\nÚj tag hozzáadva:" + tag.nev);
            }
        }

        public void DeleteTag(Tag tag)
        {
            if (klubtagok.Any(f => f.nev == tag.nev))
            {
                foreach(Foglalas foglalas in tag.foglalasok)
                {
                    foglalas.palya.FoglalasTorlese(foglalas);
                }
                klubtagok.Remove(tag);
                Console.WriteLine("\nA klubtag kilépett: " + tag.nev);
            }
            else
            {
                throw new Exception("\nNem található ilyen tag: " + tag.nev);
            }
        }

        public void FoglalasKezelese(Tag tag, int sorszam, DateOnly datum, int ora)
        {
            if(palyak.Any(f=> f.sorszam == sorszam))
            {
                if(ora > 20 || ora < 6)
                {
                    throw new Exception("\nEbben az órában nem lehet foglalni.");
                }
                else
                {
                    Palya palya = palyak.Find(f => f.sorszam == sorszam);
                    if (palya.vanFoglalas(datum, ora))
                    {
                        throw new Exception("\nA pálya már foglalt ezen az időponton.");
                    }
                    Foglalas foglalas = new Foglalas(tag, datum, ora, palya);
                    tag.FoglalasHozzadasa(foglalas);
                    palya.FoglalasHozzadasa(foglalas);
                    Console.WriteLine("\nFoglalás sikeres");
                } 
            }
            else
            {
                throw new Exception("\nNincs Ilyen pálya.");
            }
        }

        public void FoglalasLemondas(Tag tag, int sorszam, DateOnly datum, int ora)
        {
            if (palyak.Any(f=> f.sorszam == sorszam)) 
            {
                Palya palya = palyak.Find(f => f.sorszam == sorszam);
                Foglalas foglalas = palya.getFoglalás(datum, ora);
                if(foglalas == null || foglalas.foglalo != tag)
                {
                    throw new Exception("\nNem található ilyen foglalás.");
                }
                else
                {
                    tag.FoglalasTorlese(foglalas);
                    palya.FoglalasTorlese(foglalas);
                    Console.WriteLine("\nFoglalas lemondva");
                }
            }
            else
            {
                throw new Exception ("\nNem található ilyen pálya");
            }
        }

        public int NapiBevet(DateOnly datum)
        {
            int osszeg = 0;
            foreach (Palya palya in palyak)
            {
                foreach(Foglalas foglalas in palya.foglalasok)
                {
                    
                    if(foglalas.datum == datum)
                    {
                        osszeg += foglalas.palya.OraDij();
                    }
                }
            
            }
            return (osszeg);  
        }

        public void FoglalhatoPalyak(DateOnly datum, int ora, string boritas)
        {
            if ((boritas != "füves") && (boritas != "műanyag") && (boritas != "salakos"))
            {
                throw new Exception("\nHibás pálya típus.\nLehetőségek: füves, salakos, műanyag");
            }
            else
            {
                List<Palya> foglalhato = new List<Palya>();
                Console.Write("\nFoglalható " + boritas + " pályák:\n");
                Console.WriteLine("------------------");
                foreach (Palya palya in palyak)
                {
                    if (!palya.vanFoglalas(datum, ora) && palya.tipus == boritas)
                    {
                        foglalhato.Add(palya);
                        Console.WriteLine(palya.sorszam);
                    }
                }
                if (foglalhato.Count == 0)
                {
                    Console.Write("Nincs ilyen pálya a megadott időpontra.\n");
                }
                Console.WriteLine("------------------");
            }  

        }
    }
}
