//
//
//

using System;
using System.Collections.Generic;
using System.Text;

namespace Neu
{
    public partial class Node
    {      
        internal IEnumerable<Node> Children { get; init; }

        internal SourceLocation Start { get; init; }

        internal SourceLocation End { get; init; }

        ///
        
        public Node(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
        {
            this.Children = children;
            this.Start = start;
            this.End = end;
        }
    }

    ///

    public static partial class NodeHelpers
    {
        public static String GetName(
            this Node node)
        {
            throw new Exception();
        }        
    }
}