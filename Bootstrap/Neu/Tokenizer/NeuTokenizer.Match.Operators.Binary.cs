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
        public static bool MatchBinaryOperator(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.PeekBinaryOperator() is NeuBinaryOperator)
            {
                return true;
            }

            return false;
        }
    }
}