using System;
using System.Linq;

namespace TestDrivenDevelopment
{
    public class NaiveCanonicalizer
    {
        public static string GetCanonicalForm(string searchTerm)
        {
            if (searchTerm == null)
                throw new NullReferenceException("searchTerm");

            return searchTerm
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToUpper())
                .OrderBy(x => x)
                .Aggregate("", (x, y) => x + " " + y)
                .Trim();
        }
    }
}