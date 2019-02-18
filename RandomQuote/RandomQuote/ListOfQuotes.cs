using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RandomQuote
{
    public class ListOfQuotes
    {
        public List<Quote> Quotes { get; private set; } = new List<Quote>();

        public List<string> Authors { get; private set; } = new List<string>();

        private string _filePath = Directory.GetCurrentDirectory() + @"/../../../../RandomQuote/Quotes.txt";

        public List<Quote> LoadQuotes()
        {
            ReadQuotesFromFile();
            return Quotes;
        }

        private void ReadQuotesFromFile()
        {
            string lines = File.ReadAllText(_filePath);

            QuoteBuilder(lines);
        }

        private void QuoteBuilder(string lines)
        {
            string[] items = lines.Split("\r\n\r\n");

            foreach (string item in items)
            {
                int quotePosition = 0;
                int authorPosition = 1;

                string[] quoteAndAuthor = item.Split("\r\n--");
                string quote = quoteAndAuthor[quotePosition];
                string author = quoteAndAuthor[authorPosition].Trim();

                QuoteCreator(quote, author);
            }

            Authors.Sort();
        }

        private void QuoteCreator(string quote, string author)
        {
            Quote newQuote = new Quote(quote, author);
            Quotes.Add(newQuote);

            if (!Authors.Contains(author))
            {
                Authors.Add(author);
            }
        }
    }
}
