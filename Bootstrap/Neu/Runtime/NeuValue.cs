//
//
//

using System;

namespace Neu
{
    public partial class NeuValue
    {
        public NeuValue()
            : base() { }
    }

    ///

    public partial class NeuValue
    {
        public static readonly NeuValue Undefined = new NeuUndefined();
        public static readonly NeuNil Nil = new NeuNil();
    }

    ///

    public static partial class NeuValueFunctions
    {
        public static String Dump(
            this NeuValue value)
        {
            switch (value)
            {
                default:
                    throw new Exception();
            }
        }
    }
}