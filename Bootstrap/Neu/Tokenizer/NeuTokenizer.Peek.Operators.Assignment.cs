//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

using static Neu.NeuTokenizer;

namespace Neu
{
    public static partial class NeuTokenizerFunctions
    {
        public static NeuAssignmentOperator? PeekAssignmentOperator(
            this Tokenizer<NeuToken> tokenizer)
        {
            switch (tokenizer.Peek())
            {
                case NeuAssignmentOperator op:

                    return op;

                ///

                case NeuToken t when ToAssignmentOperator(t) is NeuAssignmentOperator op:

                    tokenizer.Tokens[tokenizer.Counter] = op;

                    return op;

                ///

                default:

                    return null;
            }
        }        
    }
}