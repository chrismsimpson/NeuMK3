//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuExpression ParseAssignmentExpr(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            switch (parser.Tokenizer.Peek())
            {
                case NeuToken _:

                    var expr = parser.ParseConditionalExpr(); //start);

                    if (parser.Tokenizer.MatchAssignmentOperator())
                    {
                        return parser.ParseAssignmentExpr(start, expr);
                    }
                    else
                    {
                        return expr;
                    }

                ///
    
                default:

                    throw new Exception();
            }
        }

        public static NeuExpression ParseAssignmentExpr(
            this NeuParser parser,
            SourceLocation start,
            NeuExpression expr)
        {
            var children = new List<Node>();

            ///

            children.Add(expr);

            ///

            var assignmentOp = parser.Tokenizer.TokenizeAssignmentOperator();

            children.Add(assignmentOp);

            ///

            var rhs = parser.ParseAssignmentExpr();

            children.Add(rhs);

            ///

            if (parser.Tokenizer.MatchSemicolon())
            {
                var semicolon = parser.Tokenizer.TokenizeSemicolon();

                children.Add(semicolon);
            }

            ///

            return new NeuAssignmentExpr(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }
    }
}