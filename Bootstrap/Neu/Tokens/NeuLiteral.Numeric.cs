//
//
//

using System;

namespace Neu
{
    public partial class NeuNumericLiteral : NeuLiteral
    {
        public float Value { get; init; }

        ///

        public NeuNumericLiteral(
            String source,
            SourceLocation start,
            SourceLocation end,
            float value)
            : base(source, start, end)
        {
            this.Value = value;
        }
    }
}