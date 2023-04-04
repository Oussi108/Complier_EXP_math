using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace Compilerfor_Supmti_langauge
{


    public class LexicalAnalyzer
    {
        private readonly string input;
        private int position;

        private static readonly Dictionary<char, TokenType> operatorTokens = new Dictionary<char, TokenType>()
        {
            { '+', TokenType.Plus },
            { '-', TokenType.Minus },
            { '*', TokenType.Multiply },
            { '/', TokenType.Divide },
            { '(', TokenType.LeftParen },
            { ')', TokenType.RightParen }
        };

        public LexicalAnalyzer(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public Token GetNextToken()
        {
            if (position >= input.Length)
            {
                return new Token(TokenType.EndOfInput, "");
            }

            var currentChar = input[position];
            position++;

            if (Char.IsWhiteSpace(currentChar))
            {
                return GetNextToken();
            }

            if (operatorTokens.TryGetValue(currentChar, out var tokenType))
            {
                return new Token(tokenType, currentChar.ToString());
            }

            if (Char.IsDigit(currentChar))
            {
                var value = currentChar.ToString();
                while (position < input.Length && Char.IsDigit(input[position]))
                {
                    value += input[position];
                    position++;
                }
                return new Token(TokenType.Number, value);
            }

            throw new Exception($"Invalid character '{currentChar}' at position {position - 1}");
        }
    }
    public enum TokenType
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        Number,
        LeftParen,
        RightParen,
        EndOfInput
    }

    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"<{Type}, {Value}>";
        }
    }


}
