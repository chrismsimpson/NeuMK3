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
    public static partial class PathTokenizerFunctions
    {
        public static PathPunc RawTokenizePunc(
            this Tokenizer<PathToken> tokenizer,
            Char c,
            PathPuncType puncType)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var next = tokenizer.Scanner.Consume();

            if (next != c)
            {
                throw new Exception();
            }

            ///

            return new PathPunc(
                source: next,
                start: start,
                end: tokenizer.Scanner.GetPosition(),
                puncType: puncType);
        }

        public static PathPunc RawTokenizePunc(
            this Tokenizer<PathToken> tokenizer,
            String s,
            PathPuncType puncType)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var next = tokenizer.Scanner.ConsumeString(length: s.Length);

            if (next != s)
            {
                throw new Exception();
            }

            ///

            return new PathPunc(
                source: next,
                start: start,
                end: tokenizer.Scanner.GetPosition(),
                puncType: puncType);
        }

        ///

        private static PathPunc RawTokenizeSlash(
            this Tokenizer<PathToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('/', PathPuncType.Slash);
        }

        private static PathPunc RawTokenizeBackslash(
            this Tokenizer<PathToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('\\', PathPuncType.Backslash);
        }
    }
}