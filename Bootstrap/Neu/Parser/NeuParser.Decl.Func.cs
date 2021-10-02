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

            throw new Exception();
        }
    }
}