using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopment
{
    class Program
    {
        static void Main(string[] args)
        {
            string empty = NaiveCanonicalizer.GetCanonicalForm("");
            Console.WriteLine(empty == "");
            empty = NaiveCanonicalizer.GetCanonicalForm("     ");
            Console.WriteLine(empty == "");
            empty = NaiveCanonicalizer.GetCanonicalForm("                ");
            Console.WriteLine(empty == "");



            Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("wonderful life katie melua         "));
            Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("life          wonderful katie        melua"));



            Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("wonderful life katie melua"));
            Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("life wonderful katie melua"));
            Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("katie melua life wonderful"));

            Console.Read();
        }
    }
}
