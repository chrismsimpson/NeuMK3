//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuFuncDecl ParseFuncDecl(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var funcKeyword = parser.Tokenizer.TokenizeFunction();

            children.Add(funcKeyword);

            ///

            var id = parser.Tokenizer.TokenizeIdentifier();

            children.Add(id);

            ///

            var sig = parser.ParseFuncSig();

            children.Add(sig);

            ///

            var codeBlock = parser.ParseCodeBlock();

            children.Add(codeBlock);

            ///

            return new NeuFuncDecl(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }

    }
}