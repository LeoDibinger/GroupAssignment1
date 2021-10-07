using System;

namespace GroupAssignment1
{
    public enum GrapeVariants
    {
        CabernetSauvignon, PinotNoir, Corvina, Shiraz, Merlot, Chablis,
        Riesling, Tempranillo
    }
    public enum GrapeRegions
    {
        Bordeaux, Burgundy, Veneto, Piedmonte, RiberaDelDuero,
        NapaValley, Puglia, Pfalz
    }
    public struct Wine
    {
        public int? Year;                   // null = undefined
        public string Name;
        public GrapeVariants Grape;
        public GrapeRegions Region;

        /// <summary>
        /// Creates a string representing the content of the Wine struct
        /// </summary>
        /// <returns>string that can be printed out using Console.WriteLine</returns>
        public string StringToPrint() => $"The wine {Name} is from {Year} and it is {Grape} from the region of {Region}";


    }
    class Program
    {
        static void Main(string[] args)
        {
            const int maxNrBottles = 4;
            Wine[] myCellar = new Wine[maxNrBottles];

            Console.WriteLine($"My cellar can have maximum {maxNrBottles} bottles");


            Wine wine1 = new Wine { Year = 2000, Name = "Château Lafite Rothschild", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.Bordeaux };
            bool bOK = InsertWine(myCellar, wine1);

            Wine wine2 = new Wine { Year = 2010, Name = "Domaine de la Romanée-Conti", Grape = GrapeVariants.PinotNoir, Region = GrapeRegions.Burgundy };
            bOK = InsertWine(myCellar, wine2);

            Wine wine3 = new Wine { Year = 2005, Name = "Giuseppe Quintarelli Amarone", Grape = GrapeVariants.Corvina, Region = GrapeRegions.Veneto };
            bOK = InsertWine(myCellar, wine3);

            Wine wine4 = new Wine { Year = 2008, Name = "Sierra Cantabria", Grape = GrapeVariants.Tempranillo, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine4);
            //Console.WriteLine(bOK);

            Wine wine5 = new Wine { Year = 1992, Name = "Screaming Eagle", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine5);



            PrintWines(myCellar);
            Console.WriteLine(NrOfBottles(myCellar));
            /*Console.WriteLine("Search wine");
             string name = Console.ReadLine();
             Console.WriteLine(Search(myCellar, name));
             Console.WriteLine("Delete wine");
             string dName = Console.ReadLine();
             Console.WriteLine(Delete(myCellar, dName)); */
        }



        /// <summary>
        /// Inserts a wine into myCellar at first available position
        /// </summary>
        /// <param //name="myCellar"></param>
        /// <param //name="wine"></param>
        /// <returns>true - if insertion was possible, otherwise false</returns>
        private static bool InsertWine(Wine[] myCellar, Wine wine)
        {
            try
            {
                for (int i = 0; i < myCellar.Length; i++)
                {
                    if (myCellar[i].Year == null)
                    {
                        myCellar[i] = wine;
                        Console.WriteLine($"Added to my cellar: {wine.StringToPrint()}");

                        return true;
                    }
                }
                Console.WriteLine($"Couldn't add to my cellar: {wine.StringToPrint()}");
                return false;
            }
            catch (Exception)
            {

                throw;
            }



        }

        /// <summary>
        /// Print out all the wines in myCellar
        /// </summary>
        /// <param //name="myCellar"></param>
        private static void PrintWines(Wine[] myCellar)
        {
            int i = 0;
            foreach (var item in myCellar)
            {
                if (myCellar[i].Year != null)
                {
                    Console.WriteLine(item.StringToPrint());
                    i++;
                }
            }
        }

        /// <summary>
        /// Counts the number of bottles in myCellar. That is all items
        /// where Year is not null 
        /// </summary>
        /// <param //name="myCellar"></param>
        /// <returns>Number of bottles in myCellar</returns>
        private static int NrOfBottles(Wine[] myCellar)
        {
            int nrOfBottles = 0;
            for (int i = 0; i < myCellar.Length; i++)
            {
                if (myCellar[i].Year != null)
                {
                    nrOfBottles++;
                }

            }
            return nrOfBottles;
        }

        private static bool Search(Wine[] myCeller, string name)
        {
            foreach (var item in myCeller)
            {
                if (item.Name == null)
                {
                    continue;
                }
                if (item.Name.ToLower().Contains(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool Delete(Wine[] myCeller, string name)
        {
            int counter = 0;
            foreach (var item in myCeller)
            {
                if (item.Name == null)
                {
                    continue;
                }
                if (item.Name.ToLower().Contains(name.ToLower()))
                {
                    myCeller[counter] = default(Wine);
                    return true;
                }
                counter++;
            }
            return false;
        }
    }
}
