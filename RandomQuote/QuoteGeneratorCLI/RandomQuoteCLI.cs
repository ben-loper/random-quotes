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
                Console.WriteLine("2 - Display all quotes");
                Console.WriteLine("3 - Display quotes by author\n");
                Console.WriteLine($"Total number of quotes: {_listOfQuoteCLI.Quotes.Count}\n");
                Console.Write("Please choose an option from above: ");

                string userDecision = Console.ReadLine();

                if (userDecision == "1")
                {
                    DisplayRandomQuoteAndAuthor();
                }
                else if (userDecision == "2")
                {
                    Console.Clear();

                    foreach (Quote quote in _listOfQuoteCLI.Quotes)
                    {
                        DisplayAuthorAndQuote(quote);
                    }

                    Console.Write("Press any key to return to the main menu...");

                    Console.ReadKey();
                }
                else if (userDecision == "3")
                {
                    ByAuthorMenu();
                }
                else if (userDecision.ToLower() == "q")
                {
                    quit = true;
                }
                
            }
            
        }

        private void DisplayRandomQuoteAndAuthor()
        {
            bool quit = false;

            while (!quit)
            {
                Console.Clear();

                int quotesIndex = rdm.Next(_listOfQuoteCLI.Quotes.Count);

                Quote quote = _listOfQuoteCLI.Quotes[quotesIndex];

                Console.WriteLine(quote.RandomQuote + "\n");
                Console.WriteLine(quote.Author);
                Console.WriteLine("\n-----------------------\n");
                Console.Write("Press any key to display another random quote or press \"Q\" to return to the main menu...");

                char userChoice = Console.ReadKey().KeyChar;

                if(userChoice.ToString().ToLower() == "q")
                {
                    quit = true;
                }
            }
        }
        
        private void ByAuthorMenu()
        {
            bool quit = false;

            while (!quit)
            {
                
                string selectedAuthor;
                int userDecisionNum;

                bool validChoice = false;

                try
                {
                    while (!validChoice)
                    {
                        Console.Clear();

                        Console.WriteLine("Authors:");

                        for (int i = 0; i < _listOfQuoteCLI.Authors.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {_listOfQuoteCLI.Authors[i]}");
                        }

                        Console.Write("\nSelect an author from above to display quotes or enter \"Q\" to return to the main menu: ");
                        
                        string userDecision = Console.ReadLine();

                        if(userDecision.ToLower() == "q")
                        {
                            quit = true;
                            break;
                        }

                        userDecisionNum = int.Parse(userDecision);

                        selectedAuthor = _listOfQuoteCLI.Authors[userDecisionNum - 1];

                        DisplayAuthorQuotes(selectedAuthor);

                        validChoice = true;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please only enter valid whole numbers from the list of available authors");
                    Console.WriteLine("Press any key to return to the author list...");
                    Console.ReadKey();
                }

            }
        }

        private void DisplayAuthorQuotes(string selectedAuthor)
        {
            Console.Clear();

            Console.WriteLine($"Quotes by {selectedAuthor}:\n");

            foreach (Quote quote in _listOfQuoteCLI.Quotes)
            {
                if (quote.Author == selectedAuthor)
                {
                    Console.WriteLine(quote.RandomQuote + "\n\n---------------------------\n");
                }
            }

            Console.Write("\nPress any key to return to the return to the author list menu...");
            Console.ReadKey();
        }

        private void DisplayAuthorAndQuote(Quote quote)
        {
            Console.WriteLine(quote.RandomQuote + "\n");
            Console.WriteLine(quote.Author + "\n");
            Console.WriteLine("\n----------------------\n");
        }
    }
}
