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
        public static bool MatchAssignmentOperator(
            this Tokenizer<NeuToken> tokenizer)
        {
            if (tokenizer.PeekAssignmentOperator() is NeuAssignmentOperator)
            {
                return true;
            }

            return false;
        }
    }
}