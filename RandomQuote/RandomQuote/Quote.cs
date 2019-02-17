using System;
using System.Collections.Generic;
using System.IO;

namespace RandomQuote
{
    public class Quote
    {
        public string Author { get; private set; }
        public string RandomQuote { get; private set; }

        public Quote(string quote, string author)
        {
            Author = author;
            RandomQuote = quote;
        }
    }
}
