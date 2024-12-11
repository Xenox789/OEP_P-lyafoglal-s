namespace nagyBeadando
{
    public class Program
    {
        static void Main(string[] args)
        {
            Klub klub = new Klub("Tenisz");
            klub.AddPalya("füves", false);
            klub.AddPalya("salakos", true);
            klub.AddPalya("műanyag", true);

            Tag tag1 = new Tag("Sanyi");
            Tag tag2 = new Tag("Feri");

            tag1.Belepes(klub);
            tag2.Belepes(klub);

            DateOnly DateOnly1 = new DateOnly(2023, 6, 4);
            DateOnly DateOnly2 = new DateOnly(2023, 6, 5);

            tag1.Foglalas(DateOnly1, 10, 1);
            tag1.Foglalas(DateOnly1, 11, 3);
            tag2.Foglalas(DateOnly1, 8, 1);
            tag2.Foglalas(DateOnly1, 9, 1);
            tag2.Foglalas(DateOnly2, 10, 2);
            

            tag2.Lemondas(DateOnly2, 10, 2);

            tag1.Napidij(DateOnly1);

            tag1.FoglaltPalyak(DateOnly1);

            klub.NapiBevet(DateOnly1);

            klub.FoglalhatoPalyak(DateOnly1, 11, "füves");

            klub.DeletePalya(1);
            klub.DeletePalya(2);
            klub.DeletePalya(3);

            tag1.Kilepes();
            tag2.Kilepes();


            
            




        }
    }
}