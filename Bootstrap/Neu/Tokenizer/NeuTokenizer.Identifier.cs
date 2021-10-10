//
//
//

using System;

using static System.Char;

using static Neu.NeuTokenizer;

namespace Neu
{
    public partial class NeuTokenizer
    {
        public static bool IsIdentifierPart(
            Char c)
        {
            return IsLetter(c) || IsNumber(c) || c == '_';
        }

        public static bool IsIdentifierStart(
            Char c)
        {
            return IsLetter(c) || c == '_';
        }
    }

    ///

    public static partial class NeuTokenizerFunctions
    {
        private static NeuIdentifier RawTokenizeIdentifier(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var source = tokenizer.Scanner.Consume(c => IsIdentifierPart(c));

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuIdentifier(
                source: source,
                start: start,
                end: tokenizer.Scanner.GetPosition());
        }

        ///

        public static NeuIdentifier TokenizeIdentifier(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.Next() is NeuIdentifier i)
            {
                return i;
            }

            throw new Exception();
        }
    }
}