//
//
//

using System;

namespace Neu
{
    public partial class UnknownArgToken : ArgToken
    {
        public UnknownArgToken(
            String source,
            int position)
            : base(source, position) { }
    }
}