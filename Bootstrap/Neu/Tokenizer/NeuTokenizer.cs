//
//
//

using System;
using System.Linq;

using static System.IO.File;

using static Neu.FileStreamFunctions;
using static Neu.NeuTokenizer;

namespace Neu
{
    public partial class NeuTokenizer : Tokenizer<NeuToken>
    {
        public NeuTokenizer(
            IScanner scanner)
            : base(scanner) { }
    }

    ///

    public partial class NeuTokenizer
    {
        public static NeuTokenizer FromFile(
            String file)
        {
            return new NeuTokenizer(
                new StreamScanner(NewFileStream(file, readOnly: true)));
        }
    }

    ///

    public static partial class NeuTokenizerFunctions
    {
        public static NeuToken? Next(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                var token = tokenizer.Tokens.ElementAt(tokenizer.Counter);

                tokenizer.Counter++;

                return token;
            }

            ///

            if (tokenizer.Scanner.IsEof())
            {
                return null;
            }

            ///

            var next = tokenizer.RawNext();

            tokenizer.Tokens.Add(next);

            tokenizer.Counter++;

            return next;
        }

        private static NeuToken RawNext(
            this Tokenizer<NeuToken> tokenizer)
        {
            var nextChar = tokenizer.Scanner.RawNext();

            ///

            switch (nextChar)
            {
                /// Comments

                case '/' when tokenizer.Scanner.Match(equals: '/'):
                    return tokenizer.RawTokenizeLineEndComment();

                case '/' when tokenizer.Scanner.Match(equals: '*'):
                    return tokenizer.RawTokenizeInlineComment();


                /// Pre-Operator Punctuation

                case '-' when tokenizer.Scanner.Match(equals: '>'):
                    return tokenizer.RawTokenizeArrow();


                /// Punc

                case '(':
                    return tokenizer.RawTokenizeLeftParen();

                case ')':
                    return tokenizer.RawTokenizeRightParen();

                case '{':
                    return tokenizer.RawTokenizeLeftBrace();

                case '}':
                    return tokenizer.RawTokenizeRightBrace();

                case ';':
                    return tokenizer.RawTokenizeSemicolon();

                case ':':
                    return tokenizer.RawTokenizeColon();

                case ',':
                    return tokenizer.RawTokenizeComma();

                case '=':
                    return tokenizer.RawTokenizeEqual();

                case '+':
                    return tokenizer.RawTokenizePlus();


                /// Keywords

                case 'f' when tokenizer.Scanner.MatchWithTrailingWhitespace(equals: "unc"):
                    return tokenizer.RawTokenizeFunc();

                case 'r' when tokenizer.Scanner.MatchWithTrailingWhitespace(equals: "eturn"):
                    return tokenizer.RawTokenizeReturn();


                /// Nil literal

                    // TODO


                /// Number literal

                case Char c when IsNumericLiteralStart(c):
                    return tokenizer.RawTokenizeNumericLiteral();


                /// String literal

                case Char c when IsStringLiteralStart(c):
                    throw new Exception();

                ///

                case Char c when IsIdentifierStart(c):
                    return tokenizer.RawTokenizeIdentifier();





                default:
                    throw new Exception();
            }
        }
    }
}