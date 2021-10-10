//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuAssignmentExpr : NeuExpression
    {
        public NeuAssignmentExpr(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}