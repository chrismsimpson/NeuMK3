//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuFuncSig ParseFuncSig(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var paramClause = parser.ParseParamClause();

            children.Add(paramClause);

            ///

            if (parser.Tokenizer.MatchArrow())
            {
                var returnClause = parser.ParseReturnClause();

                children.Add(returnClause);
            }

            ///

            return new NeuFuncSig(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }

        public static NeuParamClause ParseParamClause(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var leftParen = parser.Tokenizer.TokenizeLeftParen();

            children.Add(leftParen);

            ///

            var paramList = parser.ParseFuncParamList();

            children.Add(paramList);

            ///

            var rightParen = parser.Tokenizer.TokenizeRightParen();

            children.Add(rightParen);

            ///

            return new NeuParamClause(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }
        
        public static NeuFuncParamList ParseFuncParamList(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var parameters = parser.ParseFuncParams();

            ///

            return new NeuFuncParamList(
                children: parameters,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }

        public static IEnumerable<NeuFuncParam> ParseFuncParams(
            this NeuParser parser)
        {
            var parameters = new List<NeuFuncParam>();

            ///

            while (!parser.Tokenizer.IsEof())
            {
                if (parser.Tokenizer.MatchRightParen())
                {
                    break;
                }

                ///

                var param = parser.ParseFuncParam();

                parameters.Add(param);
            }

            ///

            return parameters;
        }

        public static NeuFuncParam ParseFuncParam(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var name = parser.Tokenizer.TokenizeIdentifier();

            children.Add(name);

            ///

            var colon = parser.Tokenizer.TokenizeColon();

            children.Add(colon);

            ///

            if (parser.Tokenizer.MatchComma())
            {
                var comma = parser.Tokenizer.TokenizeComma();

                children.Add(comma);
            }

            ///

            return new NeuFuncParam(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }

        ///

        public static NeuReturnClause ParseReturnClause(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var arrow = parser.Tokenizer.TokenizeArrow();

            children.Add(arrow);

            ///

            var returnType = parser.ParseReturnType();

            children.Add(returnType);

            ///

            return new NeuReturnClause(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }

        public static NeuNode ParseReturnType(
            this NeuParser parser)
        {
            if (parser.Tokenizer.MatchLeftParen())
            {
                return parser.ParseTupleType();
            }

            return parser.ParseSimpleTypeId();
        }
    }
}