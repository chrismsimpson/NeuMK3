//
//
//

using System;

namespace Neu
{
    public static partial class NeuParserHelpers
    {
        public static NeuSimpleTypeId ParseSimpleTypeId(
            this NeuParser parser)
        {
            var start = parser.Tokenizer.GetPosition();

            ///

            var identifier = parser.Tokenizer.TokenizeIdentifier();

            ///

            return parser.ParseSimpleTypeId(start, identifier);
        }

        public static NeuSimpleTypeId ParseSimpleTypeId(
            this NeuParser parser,
            SourceLocation start,
            NeuIdentifier identifier)
        {
            return new NeuSimpleTypeId(
                children: new Node[] { identifier },
                start: start,
                end: parser.Tokenizer.GetPosition());
        }
    }
}