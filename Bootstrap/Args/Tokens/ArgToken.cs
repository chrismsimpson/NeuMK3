//
//
//

using System;

namespace Neu
{
    public partial class ArgToken
    {
        public String Source { get; init; }

        public int Position { get; init; }

        ///

        public ArgToken(
            String source,
            int position)
        {
            this.Source = source;
            this.Position = position;
        }
    }
}