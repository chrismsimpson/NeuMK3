//
//
//

using System;

namespace Neu
{
    public partial class NeuTokenizer
    {
        public static NeuAssignmentOperatorType? ToAssignmentOperatorType(
            NeuToken token)
        {
            switch (token)
            {
                case NeuPunc p when p.PuncType == NeuPuncType.Equal:
                    return NeuAssignmentOperatorType.Assign;

                ///
                
                default:
                    return null;
            }
        }

        public static NeuAssignmentOperator? ToAssignmentOperator(
            NeuToken token)
        {
            switch (ToAssignmentOperatorType(token))
            {
                case NeuAssignmentOperatorType t:

                    return new NeuAssignmentOperator(
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
        public static NeuAssignmentOperator TokenizeAssignmentOperator(
            this Tokenizer<NeuToken> tokenizer)
        {
            switch (tokenizer.Next())
            {
                case NeuAssignmentOperator op:

                    return op;

                ///
                
                case var t:

                    throw new Exception($"Unexpected: {t}");
            }
        }
    }
}