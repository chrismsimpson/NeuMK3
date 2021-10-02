//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuComment : NeuToken
    {
        public NeuComment(
            String source,
            SourceLocation start,
            SourceLocation end)
            : base(source, start, end) { }
    }
}