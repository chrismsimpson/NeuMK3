//
//
//

using System;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuTupleType : NeuNode
    {
        public NeuTupleType(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public partial class NeuTupleTypeElement : NeuNode
    {
        public NeuTupleTypeElement(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }

    ///

    public partial class NeuTupleTypeElementList : NeuNode
    {
        public NeuTupleTypeElementList(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
            : base(children, start, end) { }
    }
}