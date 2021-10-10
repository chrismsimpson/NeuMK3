//
//
//

using System;

namespace Neu
{
    public partial class NeuTokenizer
    {
        public static NeuBinaryOperatorType? ToBinaryOperatorType(
            NeuToken token)
        {
            switch (token)
            {
                default:
                    return null;
            }
        }

        public static NeuBinaryOperator? ToBinaryOperator(
            NeuToken token)
        {
            switch (ToBinaryOperatorType(token))
            {
                case NeuBinaryOperatorType t:

                    return new NeuBinaryOperator(
                        source: token.Source,
                        start: token.Start,
                        end: token.End,
                        operatorType: t);

                ///

                default:

                    return null;
            }
        }
    }

    ///

    public static partial class NeuTokenizerFunctions
    {
        public static NeuBinaryOperator TokenizeBinaryOperator(
            this Tokenizer<NeuToken> tokenizer)
        {
            switch (tokenizer.Next())
            {
                case NeuBinaryOperator op:

                    return op;

                ///
                
                case var t:

                    throw new Exception($"Unexpected: {t}");
            }
        }
    }
}