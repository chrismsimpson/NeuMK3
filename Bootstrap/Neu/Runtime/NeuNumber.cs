//
//
//

using System;

namespace Neu
{
    public partial class NeuNumber : NeuValue
    {
        public NeuNumber()
            : base() { }
    }

    ///

    public partial class NeuFloat : NeuNumber
    {
        public float Value { get; init; }

        ///

        public NeuFloat(
            float value)
            : base()
        {
            this.Value = value;
        }
    }

    ///

    public enum NeuIntegerType
    {
        Int32
    }

    public partial class NeuInteger : NeuNumber
    {
        public NeuIntegerType IntegerType { get; init; }

        public byte[] Value { get; init; }

        ///

        public NeuInteger(
            NeuIntegerType integerType,
            byte[] value)
            : base()
        {
            this.IntegerType = integerType;
            this.Value = value;
        }

        public NeuInteger(
            
        )
        {

        }
    }
}