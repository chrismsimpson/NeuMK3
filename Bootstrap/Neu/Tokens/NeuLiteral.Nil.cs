//
//
//

using System;

namespace Neu
{
    public partial class NeuNilLiteral : NeuLiteral
    {
        public NeuNilLiteral(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }
}