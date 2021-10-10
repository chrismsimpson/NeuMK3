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
        public static NeuBinaryOperator? PeekBinaryOperator(
            this Tokenizer<NeuToken> tokenizer)
        {
            switch (tokenizer.Peek())
            {
                case NeuBinaryOperator op:

                    return op;

                ///

                case NeuToken t when ToBinaryOperator(t) is NeuBinaryOperator op:

                    tokenizer.Tokens[tokenizer.Counter] = op;

                    return op;

                ///

                default:

                    return null;
            }
        }        
    }
}