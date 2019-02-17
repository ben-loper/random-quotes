using RandomQuote;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteGeneratorCLI
{
    public class RandomQuoteCLI
    {
        private ListOfQuotes _listOfQuoteCLI;

        private Random rdm = new Random();

        public RandomQuoteCLI(ListOfQuotes quoteCLI)
        {
            _listOfQuoteCLI = quoteCLI;
        }

        public void MainMenu()
        {
            _listOfQuoteCLI.LoadQuotes();

            bool quit = false;

            while (!quit)
            {
                Console.Clear();

                Console.WriteLine("1 - Display a random quote");
                Console.WriteLine("2 - Display all quotes\n");
                Console.Write("Please choose an option from above: ");

                char userDecsion = Console.ReadKey().KeyChar;

                if (userDecsion.ToString() == "1")
                {
                    Console.Clear();

                    int quotesIndex = rdm.Next(_listOfQuoteCLI.quotes.Count);

                    Quote quote = _listOfQuoteCLI.quotes[quotesIndex];

                    DisplayQuoteAndAuthor(quote);

                    Console.ReadKey();
                }
                else if (userDecsion.ToString() == "2")
                {
                    Console.Clear();

                    foreach(Quote quote in _listOfQuoteCLI.quotes)
                    {
                        DisplayQuoteAndAuthor(quote);                
                    }

                    Console.ReadKey();
                }
                else if (userDecsion.ToString().ToLower() == "q")
                {
                    quit = true;
                }
                
            }
            
        }

        public void DisplayQuoteAndAuthor(Quote quote)
        {
            Console.WriteLine(quote.RandomQuote + "\n");
            Console.WriteLine(quote.Author);
            Console.WriteLine("-----------------------\n");
        }
        
    }
}
