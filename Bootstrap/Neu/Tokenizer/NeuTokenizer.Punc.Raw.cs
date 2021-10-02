//
//
//

using System;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        private static NeuPunc RawTokenizePunc(
            this Tokenizer<NeuToken> tokenizer,
            Char c,
            NeuPuncType puncType)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var next = tokenizer.Scanner.Consume();

            if (next != c)
            {
                throw new Exception();
            }

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuPunc(
                source: next,
                start: start,
                end: tokenizer.Scanner.GetPosition(),
                puncType: puncType);
        }


        private static NeuPunc RawTokenizePunc(
            this Tokenizer<NeuToken> tokenizer,
            String s,
            NeuPuncType puncType)
        {
            var start = tokenizer.Scanner.GetPosition();

            ///

            var next = tokenizer.Scanner.ConsumeString(s.Length);

            if (next != s)
            {
                throw new Exception();
            }

            ///

            tokenizer.Scanner.ConsumeWhitespace();

            ///

            return new NeuPunc(
                source: next,
                start: start,
                end: tokenizer.Scanner.GetPosition(),
                puncType: puncType);
        }

        ///

        private static NeuPunc RawTokenizeLeftParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('(', NeuPuncType.LeftParen);
        }

        private static NeuPunc RawTokenizeRightParen(
            this Tokenizer<NeuToken> tokenizer)
        {   
            return tokenizer.RawTokenizePunc(')', NeuPuncType.RightParen);
        }

        private static NeuPunc RawTokenizeLeftBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('{', NeuPuncType.LeftBrace);
        }

        private static NeuPunc RawTokenizeRightBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc('}', NeuPuncType.RightBrace);
        }

        private static NeuPunc RawTokenizeSemicolon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc(';', NeuPuncType.Semicolon);
        }

        private static NeuPunc RawTokenizeComma(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.RawTokenizePunc(',', NeuPuncType.Comma);
        }
    }
}
