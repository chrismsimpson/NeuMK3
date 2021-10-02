//
//
//

using System;
using System.Linq;
using System.Collections.Generic;

namespace Neu
{
    public partial class NeuFrame : Frame
    {
        public NeuFrame() { }
    }

    ///

    public partial class NeuNodeFrame : NeuFrame
    {
        public NeuNode Node { get; init; }

        ///

        public NeuNodeFrame(
            NeuNode node)
            : base()
        {
            this.Node = node;
        }
    }

    ///

    public partial class NueHoistedFrame : NeuFrame
    {
        public NeuHoist Hoist { get; init; }

        public NeuValue Value  { get; init; }

        ///

        public NueHoistedFrame(
            NeuHoist hoist,
            NeuValue value)
            : base()
        {
            this.Hoist = hoist;
            this.Value = value;
        }
    }
}