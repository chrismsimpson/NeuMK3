//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuExpression ParseExpression(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var expr = parser.ParseAssignmentExpr();

            ///

            if (parser.Tokenizer.MatchComma())
            {

            }

            throw new Exception();
        }
    }
}