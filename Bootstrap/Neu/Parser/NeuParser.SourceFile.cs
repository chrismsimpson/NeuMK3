//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuSourceFile ParseSourceFile(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var list = parser.ParseCodeBlockItemList();

            children.Add(list);

            ///

            return new NeuSourceFile(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }
    }
}