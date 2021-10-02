//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class ArgsTokenizerFunctions
    {
        public static ArgToken? Peek(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Counter + 1 <= tokenizer.Tokens.Count)
            {
                return tokenizer.Tokens.ElementAt(tokenizer.Counter);
            }

            ///

            if (tokenizer.Scanner.IsEof())
            {
                return null;
            }

            ///

            var next = tokenizer.RawNext();

            tokenizer.Tokens.Add(next);

            ///

            return next;
        }

        public static bool MatchOptionToken(
            this ArgsTokenizer tokenizer)
        {
            if (tokenizer.Peek() is OptionToken)
            {
                return true;
            }

            return false;
        }
    }
}