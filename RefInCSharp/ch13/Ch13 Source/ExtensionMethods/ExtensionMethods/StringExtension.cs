using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        public static String[] SplitReturningDelimiter(this String str, 
            char[] delimiter)
        {
            String[] split = str.Split(delimiter, 
                StringSplitOptions.None);
            String delimiterString = new String(delimiter);
            int position = 0;
            String[] result = new String[(2 * split.Length) - 1];

            foreach (String token in split)
            {
                result[position] = token;
                position++;
                if (position < result.Length - 1)
                {
                    result[position] = delimiterString;
                    position++;
                }
            }
            if (str.StartsWith(delimiterString))
            {
                String[] whenStartsWithDelimiter = new String[
                    result.Length - 1];
                Array.ConstrainedCopy(result, 1, 
                    whenStartsWithDelimiter, 0, result.Length - 1);
                result = whenStartsWithDelimiter;

            }
            if (str.EndsWith(delimiterString))
            {
                String[] whenEndsWithDelimiter = new String[
                    result.Length - 1];
                Array.ConstrainedCopy(result, 0, 
                    whenEndsWithDelimiter, 0, result.Length - 1);
                result = whenEndsWithDelimiter;

            }
            return result;

        }
    }
}
