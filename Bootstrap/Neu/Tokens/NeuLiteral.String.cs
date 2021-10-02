//
//
//

using System;

namespace Neu
{
    public partial class NeuStringLiteral : NeuLiteral
    {
        public NeuStringLiteral(
            String source,
            String rawSource,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }
}