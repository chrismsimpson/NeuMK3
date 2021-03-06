//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuStatement ParseStatement(
            this NeuParser parser)
        {
            switch (parser.Tokenizer.Peek())
            {
                /// Keywords

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Return:
                    return parser.ParseReturnStatement();

                ///

                case var p:
                    throw new Exception($"Unsupported: {p}");
            }
        }
    }
}