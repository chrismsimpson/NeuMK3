//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuExpression : NeuStatement
    {
        public NeuExpression(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}