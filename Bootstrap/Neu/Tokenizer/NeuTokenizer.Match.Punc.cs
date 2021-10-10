//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        public static bool MatchPunc(
            this Tokenizer<NeuToken> tokenizer,
            params NeuPuncType[] puncTypes)
        {
            if (tokenizer.Peek() is NeuPunc p && puncTypes.Contains(p.PuncType))
            {
                return true;
            }

            return false;
        }

        ///

        public static bool MatchArrow(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.MatchPunc(NeuPuncType.Arrow);
        }

        public static bool MatchComma(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.MatchPunc(NeuPuncType.Comma);
        }

        public static bool MatchLeftParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.MatchPunc(NeuPuncType.LeftParen);
        }

        public static bool MatchRightParen(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.MatchPunc(NeuPuncType.RightParen);
        }

        public static bool MatchSemicolonOrRightBrace(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.MatchPunc(NeuPuncType.Semicolon, NeuPuncType.RightBrace);
        }

        public static bool MatchSemicolon(
            this Tokenizer<NeuToken> tokenizer)
        {
            return tokenizer.MatchPunc(NeuPuncType.Semicolon);
        }
    }
}