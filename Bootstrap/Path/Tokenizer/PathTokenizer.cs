//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.String;

using static Neu.PathTokenizer;

namespace Neu
{
    public partial class PathTokenizer : Tokenizer<PathToken>
    {
        public PathTokenizer(
            IScanner scanner)
            : base(scanner) { }
    }

    ///

    public partial class PathTokenizer
    {
        public static PathTokenizer FromString(
            String source)
        {
            return new PathTokenizer(
                new StringScanner(source));
        }

        ///

        public static bool IsComponentPart(
            Char c)
        {
            return
                c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' ||
                c == 'a' || c == 'b' || c == 'c' || c == 'd' || c == 'e' || c == 'f' || c == 'g' || c == 'h' || c == 'i' || c == 'j' || c == 'k' || c == 'l' || c == 'm' || c == 'n' || c == 'o' || c == 'p' || c == 'q' || c == 'r' || c == 's' || c == 't' || c == 'u' || c == 'v' || c == 'w' || c == 'x' || c == 'y' || c == 'z' ||
                c == 'A' || c == 'B' || c == 'C' || c == 'D' || c == 'E' || c == 'F' || c == 'G' || c == 'H' || c == 'I' || c == 'J' || c == 'K' || c == 'L' || c == 'M' || c == 'N' || c == 'O' || c == 'P' || c == 'Q' || c == 'R' || c == 'S' || c == 'T' || c == 'U' || c == 'V' || c == 'W' || c == 'X' || c == 'Y' || c == 'Z' ||
                c == '.' || c == ' ' || c == '-' || c == '_';
        }
    }

    ///

    public static partial class PathTokenizerFunctions
    {
        public static PathToken? Next(
            this Tokenizer<PathToken> tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                var token = tokenizer.Tokens.ElementAt(tokenizer.Counter);
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

        ///
    
        private static PathToken RawNext(
            this Tokenizer<PathToken> tokenizer)
        {
            var nextChar = tokenizer.Scanner.RawNext();

            ///

            switch (nextChar)
            {
                /// Punc

                case '/':
                    return tokenizer.RawTokenizeSlash();

                case '\\':
                    return tokenizer.RawTokenizeBackslash();

                /// Special Dir

                case '.' when tokenizer.Scanner.Match(equals: '.'):
                    return tokenizer.RawTokenizeParentDirectoryComponent();

                case '.':
                    return tokenizer.RawTokenizeCurrentDirectoryComponent();

                ///

                case Char c when IsComponentPart(c):
                    return tokenizer.RawTokenizeComponent();

                ///

                default:
                    throw new Exception();
            }
        }
    }
}