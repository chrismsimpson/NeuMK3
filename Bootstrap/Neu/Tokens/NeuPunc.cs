//
//
//

using System;

namespace Neu
{
    public enum NeuPuncType
    {
        LeftParen,
        RightParen,

        LeftBrace,
        RightBrace,

        Semicolon,
        Comma,

        Arrow,
        Colon,

        Equal,
        Plus
    }

    ///

    public partial class NeuPunc : NeuToken
    {
        public NeuPuncType PuncType { get; init; }

        ///

        public NeuPunc(
            Char source,
            SourceLocation start,
            SourceLocation end,
            NeuPuncType puncType)
            : base(new String(new Char[] { source }), start, end)
        {
            this.PuncType = puncType;
        }

        public NeuPunc(
            String source,
            SourceLocation start,
            SourceLocation end,
            NeuPuncType puncType)
            : base(source, start, end)
        {
            this.PuncType = puncType;
        }
    }
}