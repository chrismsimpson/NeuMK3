//
//
//

using System;

namespace Neu
{
    public enum NeuBinaryOperatorType
    {
        Multiply,
        Divide,
        Add,
        Subtract
    }

    public partial class NeuBinaryOperator : NeuOperator
    {
        public NeuBinaryOperatorType OperatorType { get; init; }

        ///

        public NeuBinaryOperator(
            Char source,
            SourceLocation start,
            SourceLocation end,
            NeuBinaryOperatorType operatorType)
            : base(new String(new Char[] { source }), start, end)
        {
            this.OperatorType = operatorType;
        }

        public NeuBinaryOperator(
            String source,
            SourceLocation start,
            SourceLocation end,
            NeuBinaryOperatorType operatorType)
            : base(source, start, end)
        {
            this.OperatorType = operatorType;
        }
    }
}