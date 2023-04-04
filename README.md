# Complier_EXP_math
simple complier for math expression
The compiler is a simple language compiler built in C#. It consists of two main components: a lexical analyzer and a parser.

The lexical analyzer, or lexer, is responsible for taking a source code string and converting it into a sequence of tokens. Tokens are individual pieces of the source code that represent a specific unit of meaning, such as a number or an operator. The lexer uses regular expressions to match the input string against a set of predefined patterns and produces tokens based on the matches it finds.

The parser takes the stream of tokens produced by the lexer and converts it into an abstract syntax tree (AST), which represents the structure and meaning of the program. The parser uses a set of grammar rules to match and combine tokens into larger structures, such as expressions and statements, based on their meaning and syntax.

The current implementation of the compiler supports simple arithmetic expressions, consisting of numbers, addition, subtraction, multiplication, and division. The compiler can also handle parentheses to group expressions and enforce order of operations.

Additionally, the compiler has been updated to support variables and assignments. Users can define variables with identifier tokens and assign values to them using the assignment operator =. The compiler uses a symbol table to keep track of variable names and their values during execution.

Finally, the compiler has been updated to support additional operators, such as exponentiation, modulus, and bitwise operators. This expands the range of mathematical and logical operations that users can perform in their programs.
