using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilerfor_Supmti_langauge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "3 + 4 * (2 - 2)";
            LexicalAnalyzer lexer = new LexicalAnalyzer(input);
            Parser parser = new Parser(lexer);
            int result = parser.Parse();
            Console.WriteLine($"Input: {input}, Output: {result}");
            Console.ReadLine();
        }
    }
}
