//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        private static NeuKeyword RawTokenizeKeyword(
            this Tokenizer<NeuToken> tokenizer,
            String s,
            NeuKeywordType keywordType)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var next = tokenizer.Scanner.ConsumeString(length: s.Length);

            ///

            if (next != s)
            {
                throw new Exception();
            }

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuKeyword(
                source: next,
                start: start,
                end: tokenizer.Scanner.GetPosition(),
                keywordType: keywordType);
        }

        ///

        private static NeuKeyword RawTokenizeFunc(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("func", NeuKeywordType.Func);
        }

        private static NeuKeyword RawTokenizeReturn(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizeKeyword("return", NeuKeywordType.Return);
        }
    }
}