//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        public static NeuPunc TokenizePunc(
            this Tokenizer<NeuToken> tokenizer,
            NeuPuncType puncType)
        {
            if (tokenizer.Next() is NeuPunc p && p.PuncType == puncType)
            {
                return p;
            }

            ///

            throw new Exception();
        }

        ///

        public static NeuPunc TokenizeLeftParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunc(NeuPuncType.LeftParen);
        }

        public static NeuPunc TokenizeRightParen(
            this Tokenizer<NeuToken> tokenizer)
        {   
            return tokenizer.TokenizePunc(NeuPuncType.RightParen);
        }

        public static NeuPunc TokenizeLeftBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunc(NeuPuncType.LeftBrace);
        }

        public static NeuPunc TokenizeRightBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunc(NeuPuncType.RightBrace);
        }

        public static NeuPunc TokenizeSemicolon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunc(NeuPuncType.Semicolon);
        }

        public static NeuPunc TokenizeComma(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunc(NeuPuncType.Comma);
        }

        public static NeuPunc TokenizeColon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunc(NeuPuncType.Colon);
        }

        public static NeuPunc TokenizeArrow(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.TokenizePunc(NeuPuncType.Arrow);
        }
    }
}
