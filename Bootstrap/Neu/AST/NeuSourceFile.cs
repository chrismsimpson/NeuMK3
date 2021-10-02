//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuSourceFile : NeuNode
    {
        public NeuSourceFile(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}