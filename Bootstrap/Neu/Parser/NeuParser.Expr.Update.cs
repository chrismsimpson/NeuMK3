//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuExpression ParseUpdateExpression(
            this NeuParser parser)
        {
            return parser.ParseLHSExpressionAllowCall();
        }

        public static NeuExpression ParseLHSExpressionAllowCall(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

                // TODO: 

            var expr = parser.ParsePrimaryExpression();

            throw new Exception();
        }
    }
}