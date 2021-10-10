//
//
//

using System;

using static System.Buffers.Binary.BinaryPrimitives;

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
        public Endianness Endianness { get; init; }

        public NeuIntegerType IntegerType { get; init; }

        public byte[] Value { get; init; }

        ///

        public NeuInteger(
            Endianness endianness,
            NeuIntegerType integerType,
            byte[] value)
            : base()
        {
            this.Endianness = endianness;
            this.IntegerType = integerType;
            this.Value = value;
        }

        public NeuInteger(
            Endianness endianness,
            int value)
        {
            this.Endianness = endianness;

            ///

            this.IntegerType = NeuIntegerType.Int32;

            ///

            switch (this.Endianness)
            {
                case Endianness.Big:

                    var bigInt32 = new Span<Byte>();

                    if (!TryWriteInt32BigEndian(bigInt32, value))
                    {
                        throw new Exception();
                    }

                    this.Value = bigInt32.ToArray();

                    break;

                ///

                case Endianness.Little:

                    var littleInt32 = new Span<Byte>();

                    if (!TryWriteInt32LittleEndian(littleInt32, value))
                    {
                        throw new Exception();
                    }

                    this.Value = littleInt32.ToArray();

                    break;

                ///

                default:

                    throw new Exception($"Unknown endianness");
            }
        }

        public NeuInteger(
            int value)
            : this(Endianness.Little, value) { } // This is an x86 default?
    }
}