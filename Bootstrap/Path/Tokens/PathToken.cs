//
//
//

using System;

namespace Neu
{
    public partial class PathToken : Token
    {
        public PathToken(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }
}