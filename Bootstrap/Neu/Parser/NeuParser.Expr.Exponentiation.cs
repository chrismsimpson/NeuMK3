//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuExpression ParseExponentiationExpression(
            this NeuParser parser)
        {
            return parser.ParseUnaryExpression();
        }
    }
}