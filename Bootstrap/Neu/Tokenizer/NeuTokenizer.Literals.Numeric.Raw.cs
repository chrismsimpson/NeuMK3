//
//
//

using System;

using static System.String;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        private static NeuNumericLiteral RawTokenizeNumericLiteral(
            this Tokenizer<NeuToken> tokenizer)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var next = tokenizer.Scanner.Consume(c => IsNumericLiteralPart(c));

            float value = 0;

            if (!float.TryParse(next, out value))
            {
                throw new Exception();
            }

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuNumericLiteral(
                source: next,
                start: start,
                end: tokenizer.Scanner.GetPosition(),
                value: value);
        }
    }
}