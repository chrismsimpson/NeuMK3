//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static System.Char;
using static System.IO.File;
using static System.String;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        public static NeuComment RawTokenizeLineEndComment(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var source = tokenizer.Scanner.ConsumeUntil(c => c == '\n');

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuComment(
                source: source,
                start: start,
                end: tokenizer.Scanner.GetPosition());
        }

        ///

        public static NeuComment RawTokenizeInlineComment(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var source = tokenizer.Scanner.ConsumeUntilInclusive("*/");

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuComment(
                source: source,
                start: start,
                end: tokenizer.Scanner.GetPosition());
        }
    }
}