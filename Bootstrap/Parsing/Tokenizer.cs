//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class Tokenizer<T> where T : Token
    {
        internal IScanner Scanner { get; init; }

        internal IList<T> Tokens { get; init; }

        internal int Counter { get; set; }

        ///

        public Tokenizer(
            IScanner scanner)
        {
            this.Scanner = scanner;

            this.Tokens = new List<T>();

            this.Counter = 0;
        }
    }

    ///

    public static partial class TokenizerFunctions
    {
        public static bool IsEof<T>(
            this Tokenizer<T> tokenizer)
            where T : Token
        {
            if (tokenizer.GetPosition().RawPosition == tokenizer.Scanner.GetPosition().RawPosition)
            {
                return tokenizer.Scanner.IsEof();
            }

            return false;
        }

        public static SourceLocation GetPosition<T>(
            this Tokenizer<T> tokenizer)
            where T : Token
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(tokenizer.Counter).Start;
            }

            return tokenizer.Scanner.GetPosition();
        }

        public static T? GetPrevious<T>(
            this Tokenizer<T> tokenizer,
            int steps = 1)
            where T : Token
        {
            var prev = tokenizer.Counter - steps;

            if (prev < 0)
            {
                return null;
            }

            if (tokenizer.Counter <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(prev);
            }

            return null;
        }
    }
}