//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuExpression ParseBinaryExpression(
            this NeuParser parser)
        {
            var expr = parser.ParseExponentiationExpression();

            ///

            switch (parser.Tokenizer.Peek())
            {
                case NeuPunc p when p.PuncType == NeuPuncType.RightBrace || p.PuncType == NeuPuncType.Semicolon:
                    return expr;

                ///

                default:
                    break;
            }

            ///

            if (parser.Tokenizer.MatchBinaryOperator())
            {
                
            }

            throw new Exception();
        }
    }
}