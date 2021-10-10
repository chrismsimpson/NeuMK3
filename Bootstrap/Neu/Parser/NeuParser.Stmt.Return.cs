//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuReturnStatement ParseReturnStatement(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var returnKeyword = parser.Tokenizer.TokenizeReturn();

            children.Add(returnKeyword);

            ///

            if (!parser.Tokenizer.MatchSemicolonOrRightBrace())
            {
                var expr = parser.ParseExpression();

                if (expr == null)
                {
                    throw new Exception();
                }

                children.Add(expr);
            }

            ///

            return new NeuReturnStatement(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }
    }
}