using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteGeneratorCLI
{
    public static class CLIHelper
    {
        public static void RangeIntDecision(string firstOption, string lastOption, string userDecision)
        {
            bool isValid = false;

            try
            {
               int.TryParse(userDecision, out int choice);
            }
            catch
            {

            }
        }
    }
}
