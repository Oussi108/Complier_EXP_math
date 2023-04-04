using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Compilerfor_Supmti_langauge
{

    public class Parser
    {
        private readonly LexicalAnalyzer lexer;
        private Token currentToken;

        public Parser(LexicalAnalyzer lexer)
        {
            this.lexer = lexer;
            currentToken = this.lexer.GetNextToken();
        }

        private void Eat(TokenType tokenType)
        {
            if (currentToken.Type == tokenType)
            {
                currentToken = lexer.GetNextToken();
            }
            else
            {
                throw new Exception($"Unexpected token '{currentToken.Value}', expected '{tokenType}'");
            }
        }

        private int Factor()
        {
            var token = currentToken;
            if (token.Type == TokenType.Number)
            {
                Eat(TokenType.Number);
                return int.Parse(token.Value);
            }
            else if (token.Type == TokenType.LeftParen)
            {
                Eat(TokenType.LeftParen);
                var result = Expr();
                Eat(TokenType.RightParen);
                return result;
            }
            else
            {
                throw new Exception($"Unexpected token '{token.Value}', expected number or left parenthesis");
            }
        }

        private int Term()
        {
            var result = Factor();

            while (currentToken.Type == TokenType.Multiply || currentToken.Type == TokenType.Divide)
            {
                var token = currentToken;
                if (token.Type == TokenType.Multiply)
                {
                    Eat(TokenType.Multiply);
                    result *= Factor();
                }
                else if (token.Type == TokenType.Divide)
                {
                    Eat(TokenType.Divide);
                    result /= Factor();
                }
            }

            return result;
        }

        private int Expr()
        {
            var result = Term();

            while (currentToken.Type == TokenType.Plus || currentToken.Type == TokenType.Minus)
            {
                var token = currentToken;
                if (token.Type == TokenType.Plus)
                {
                    Eat(TokenType.Plus);
                    result += Term();
                }
                else if (token.Type == TokenType.Minus)
                {
                    Eat(TokenType.Minus);
                    result -= Term();
                }
            }

            return result;
        }

        public int Parse()
        {
            return Expr();
        }
    }



}


