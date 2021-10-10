//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuExpression ParseConditionalExpr(
            this NeuParser parser)
        {
            return parser.ParseBinaryExpression();
        }
    }
}