//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public static partial class NeuParserFunctions
    {
        public static NeuCodeBlockItemList ParseCodeBlockItemList(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var items = parser.ParseCodeBlockItems();

            ///

            return new NeuCodeBlockItemList(
                children: items,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }

        ///

        public static IEnumerable<NeuCodeBlockItem> ParseCodeBlockItems(
            this NeuParser parser)
        {
            var items = new List<NeuCodeBlockItem>();

            ///

            var done = false;

            while (!parser.Tokenizer.IsEof() && !done)
            {
                var peek = parser.Tokenizer.Peek();

                ///

                switch (peek)
                {
                    case NeuPunc p when p.PuncType == NeuPuncType.Semicolon || p.PuncType == NeuPuncType.RightBrace:

                        done = true;

                        break;

                    ///

                    default:

                        break;
                }

                ///

                if (done)
                {
                    break;
                }

                ///

                var item = parser.ParseCodeBlockItem();

                items.Add(item);

                ///

                // TODO: Break if peek case
            }

            ///

            return items;
        }

        public static NeuCodeBlockItem ParseCodeBlockItem(
            this NeuParser parser)
        {
            switch (parser.Tokenizer.Peek())
            {
                /// Declarations

                case NeuKeyword keyword when keyword.KeywordType == NeuKeywordType.Func:
                    return parser.ParseFuncDecl();


                /// Statements

                default:
                    return parser.ParseStatement();
            }
        }

        public static NeuCodeBlock ParseCodeBlock(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var children = new List<Node>();

            ///

            var leftBrace = parser.Tokenizer.TokenizeLeftBrace();

            children.Add(leftBrace);

            ///

            var list = parser.ParseCodeBlockItemList();

            children.Add(list);

            ///

            var rightBrace = parser.Tokenizer.TokenizeRightBrace();

            children.Add(rightBrace);

            ///

            return new NeuCodeBlock(
                children: children,
                start: start,
                end: parser.Tokenizer.GetPosition());
        }
    }
}