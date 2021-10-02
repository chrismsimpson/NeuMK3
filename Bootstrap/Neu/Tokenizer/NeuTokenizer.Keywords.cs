//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        public static NeuKeyword TokenizeKeyword(
            this Tokenizer<NeuToken> tokenizer,
            NeuKeywordType keywordType)
        {
            if (tokenizer.Next() is NeuKeyword k && k.KeywordType == keywordType)
            {
                return k;
            }

            throw new Exception();
        }

        ///

        public static NeuKeyword TokenizeFunction(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizeKeyword(NeuKeywordType.Func);
        }

        public static NeuKeyword TokenizeReturn(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizeKeyword(NeuKeywordType.Return);
        }
    }
}