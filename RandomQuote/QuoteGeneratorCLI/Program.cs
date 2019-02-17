using RandomQuote;
using System;

namespace QuoteGeneratorCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ListOfQuotes quoateGenerator = new ListOfQuotes();
                RandomQuoteCLI startUp = new RandomQuoteCLI(quoateGenerator);
                startUp.MainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The following issue occured while running the random quote generator: ");
                Console.WriteLine(ex.Message);
                Console.WriteLine("The program will now close...");
                Console.ReadKey();
            }

        }
    }
}
