//
//
//

using System;

namespace Neu
{
    public partial class ArgsToken
    {
        public String Source { get; init; }

        public int Position { get; init; }

        ///

        public ArgsToken(
            String source,
            int position)
        {
            this.Source = source;
            this.Position = position;
        }
    }
}