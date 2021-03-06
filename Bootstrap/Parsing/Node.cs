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

    public static partial class NodeFunctions
    {
        public static String GetName(
            this Node node)
        {
            throw new Exception();
        }
        
        public static String Dump(
            this Node node)
        {
            return node.Dump(indent: 0);
        }

        public static String Dump(
            this Node node,
            int indent)
        {
            var i = Indent(indent);

            var t = node.GetType();

            var sb = new StringBuilder();

            if (node is Token tok)
            {
                var sourceTrimmed = tok.Source.Trim();

                switch (tok.IsString())
                {
                    case true:

                        sb.Append($"{i}{t.Name} \"{sourceTrimmed}\"");

                        break;

                    ///

                    case false:
                        
                        sb.Append($"{i}{t.Name} {sourceTrimmed}");

                        break;
                }
            }
            else
            {
                sb.Append($"{i}{t.Name}");
            }

            foreach (var c in node.Children)
            {
                sb.Append('\n');

                sb.Append(c.Dump(indent + 1));
            }

            return sb.ToString();
        }

        private static String Indent(
            int indent)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < indent; i++)
            {
                sb.Append(" ");
            }

            return sb.ToString();
        }     
    }
}