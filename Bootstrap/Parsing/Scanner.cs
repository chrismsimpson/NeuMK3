//
//
//

using System;
using System.IO;
using System.Linq;
using System.Text;

using static System.Array;
using static System.Char;
using static System.DateTimeOffset;
using static System.String;

using static Neu.Scanner;

namespace Neu
{
    public interface IScanner
    {
        int RawPosition { get; set; }

        int LineNumber { get; set; }

        int Column { get; set; }
    }

    public partial class StringScanner : IScanner
    {
        public String Source { get; init; }
        
        public int RawPosition { get; set; }

        public int LineNumber { get; set; }

        public int Column { get; set; }

        ///

        public StringScanner(
            String source)
        {
            this.Source = source;

            ///

            this.RawPosition = 0;

            ///

            this.LineNumber = 1;

            this.Column = 1;
        }
    }

    public partial class StreamScanner : IScanner
    {
        public Stream Source { get; init; }

        public StreamReader Reader { get; init; }

        public int RawPosition { get; set; }

        public int LineNumber { get; set; }

        public int Column { get; set; }

        ///

        public StreamScanner(
            Stream source)
        {
            this.Source = source;

            ///

            this.Reader = new StreamReader(this.Source);

            ///

            this.RawPosition = 0;

            ///

            this.LineNumber = 1;

            this.Column = 1;
        }

        ~StreamScanner()
        {
            this.Reader.Dispose();
            this.Source.Dispose();
        }
    }

    public static partial class IScannerFunctions
    {
        public static SourceLocation GetPosition(
            this IScanner scanner)
        {
            return new SourceLocation(
                rawPosition: scanner.RawPosition,
                lineNumber: scanner.LineNumber,
                column: scanner.Column);
        }

        public static bool IsEof(
            this IScanner scanner)
        {
            switch (scanner)
            {
                case StringScanner stringScanner:
                    return stringScanner.RawPosition >= stringScanner.Source.Length;

                ///

                case StreamScanner streamScanner:
                    return streamScanner.RawPosition >= streamScanner.Source.Length;

                ///

                default:
                    throw new Exception();
            }
        }

        internal static int GetLength(
            this IScanner scanner)
        {
            switch (scanner)
            {
                case StringScanner stringScanner:

                    return stringScanner.Source.Length;


                ///

                case StreamScanner streamScanner:

                    return Convert.ToInt32(streamScanner.Source.Length);


                ///

                default:
                    throw new Exception();
            }
        }

        private static Char[] RawConsume(
            this IScanner scanner,
            int length)
        {
            var end = scanner.RawPosition + length;

            if (end > scanner.GetLength())
            {
                throw new Exception();
            }

            ///

            switch (scanner)
            {
                case StringScanner stringScanner:

                    var stringBuffer = new Char[length];

                    for (var i = 0; i < length; i++)
                    {
                        stringBuffer[i] = stringScanner.Source[scanner.RawPosition + i];
                    }

                    return stringBuffer;


                ///

                case StreamScanner streamScanner:

                    var sourceBuffer = new char[length];

                    ///

                    streamScanner.Source.Position = streamScanner.RawPosition;

                    streamScanner.Reader.SetPosition(streamScanner.RawPosition);

                    ///

                    for (var i = 0; i < length; i++)
                    {
                        sourceBuffer[i] = Convert.ToChar(streamScanner.Reader.Read());
                    }

                    ///

                    streamScanner.Source.Position = streamScanner.RawPosition;

                    streamScanner.Reader.SetPosition(streamScanner.RawPosition);

                    ///

                    return sourceBuffer;

                ///

                default:

                    throw new Exception();
            }
        }
        
        public static Char Consume(
            this IScanner scanner)
        {
            var buffer = scanner.RawConsume(length: 1);

            if (buffer.Length != 1)
            {
                throw new Exception();
            }

            ///

            var c = buffer[0];

            ///

            switch (c)
            {
                case '\n':

                    scanner.LineNumber++;

                    scanner.Column = 0;

                    break;

                default:

                    scanner.Column++;

                    break;
            }

            ///

            scanner.RawPosition++;

            ///

            return c;
        }

        public static String ConsumeString(
            this IScanner scanner,
            int length)
        {
            var chars = scanner.RawConsume(length: length);

            if (chars.Length != length)
            {
                throw new Exception();
            }

            ///

            var maybeString = new String(chars);

            if (IsNullOrWhiteSpace(maybeString))
            {
                throw new Exception();
            }

            ///

            scanner.RawPosition += length;

            ///

            return maybeString;
        }

        public static Char Consume(
            this IScanner scanner, 
            Char c)
        {
            var next = scanner.Consume();

            if (next != c)
            {
                throw new Exception();
            }

            return next;
        }

        public static String Consume(
            this IScanner scanner, 
            String s)
        {
            var result = new StringBuilder();

            foreach (var c in s)
            {
                result.Append(scanner.Consume(c));
            }

            return result.ToString();
        }

        public static String Consume(
            this IScanner scanner, 
            Func<Char, bool> test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && test(scanner.RawNext()))
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        public static String ConsumeUntil(
            this IScanner scanner, 
            Char c)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && c != scanner.RawNext())
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        public static String ConsumeUntil(
            this IScanner scanner, 
            Func<Char, bool> test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && !test(scanner.RawNext()))
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        public static String ConsumeUntil(
            this IScanner scanner,
            String test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && !scanner.Next(equals: test))
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        public static String ConsumeUntilInclusive(
            this IScanner scanner,
            String test)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof() && !scanner.Next(equals: test))
            {
                result.Append(scanner.Consume());
            }

            result.Append(scanner.Consume(test));

            return result.ToString();
        }

        public static String ConsumeWhitespace(
            this IScanner scanner)
        {
            return scanner.Consume(c => IsWhiteSpace(c));
        }

        public static String ConsumeUntilWhitespace(
            this IScanner scanner)
        {
            return scanner.ConsumeUntil(c => IsWhiteSpace(c));
        }

        public static String ConsumeSpaceOrTabs(
            this IScanner scanner)
        {
            return scanner.Consume(c => IsSpaceOrTabs(c));
        }

        public static String ConsumeZeroThruTen(
            this IScanner scanner)
        {
            return scanner.Consume(c => IsZeroThruTen(c));
        }

        public static String ConsumeUntilEnd(
            this IScanner scanner)
        {
            var result = new StringBuilder();

            while (!scanner.IsEof())
            {
                result.Append(scanner.Consume());
            }

            return result.ToString();
        }

        ///

        public static String RawNext(
            this IScanner scanner,
            int length)
        {
            switch (scanner)
            {
                case StringScanner stringScanner:

                    return stringScanner.Source.Substring(scanner.RawPosition, length);

                ///

                case StreamScanner streamScanner:

                    var buffer = streamScanner.RawConsume(length: length);

                    if (buffer.Length != length)
                    {
                        throw new Exception();
                    }

                    ///

                    return new String(buffer);


                ///

                default:

                    throw new Exception();
            }
        }

        public static char RawNext(
            this IScanner scanner)
        {
            var next = scanner.RawNext(length: 1);

            if (next.Length != 1)
            {
                throw new Exception();
            }

            return next[0];
        }

        public static char? Next(
            this IScanner scanner)
        {
            if (scanner.IsEof())
            {
                return null;
            }

            return scanner.RawNext();
        }

        public static bool Next(
            this IScanner scanner, 
            String equals)
        {
            if (scanner.IsEof())
            {
                return false;
            }

            var start = scanner.RawPosition;

            var end = start + equals.Length;

            if (end >= scanner.GetLength())
            {
                return false;
            }

            var next = scanner.RawNext(length: equals.Length);

            return next == equals;
        }

        ///

        public static bool Match(
            this IScanner scanner,
            String equals)
        {
            if (scanner.IsEof())   
            {
                return false;
            }

            ///

            var end = scanner.RawPosition + equals.Length + 1;

            if (end >= scanner.GetLength())
            {
                return false;
            }

            ///

            var bufferLength = equals.Length + 1;

            var buffer = scanner.RawNext(bufferLength);

            if (buffer.Length != bufferLength)
            {
                throw new Exception();
            }

            ///

            var next = buffer.Substring(1);

            ///

            return next == equals;
        }

        public static bool Match(
            this IScanner scanner,
            Char equals)
        {
            if (scanner.IsEof())   
            {
                return false;
            }

            ///

            var end = scanner.RawPosition + 2;

            if (end >= scanner.GetLength())
            {
                return false;
            }

            ///

            var buffer = scanner.RawNext(length: 2);

            if (buffer.Length != 2)
            {
                throw new Exception();
            }

            ///

            var next = buffer[1];

            ///

            return next == equals;
        }

        ///

        public static bool MatchWithTrailingWhitespace(
            this IScanner scanner,
            String equals)
        {
            if (scanner.IsEof())
            {
                return false;
            }

            ///

            var end = scanner.RawPosition + equals.Length + 1;

            if (end >= scanner.GetLength())
            {
                return false;
            }

            ///

            var bufferLength = equals.Length + 2;

            var buffer = scanner.RawNext(bufferLength);

            if (buffer.Length != bufferLength)
            {
                throw new Exception();
            }

            ///

            var next = buffer.Substring(1, equals.Length);

            if (next != equals)
            {
                return false;
            }

            ///

            var possibleWhitespace = buffer[equals.Length + 1];

            ///

            return IsWhiteSpace(possibleWhitespace);
        }

        public static bool MatchWithTrailingDelimiter(
            this IScanner scanner,
            String equals,
            Func<char, bool> delimitedBy)
        {
            if (scanner.IsEof())   
            {
                return false;
            }

            ///

            var end = scanner.RawPosition + equals.Length + 1;
            
            if (end >= scanner.GetLength())
            {
                return false;
            }

            ///
            
            var bufferLength = equals.Length + 2;

            var buffer = scanner.RawNext(bufferLength);

            if (buffer.Length != bufferLength)
            {
                throw new Exception();
            }

            ///

            var next = buffer.Substring(1, equals.Length);

            if (next != equals)
            {
                return false;
            }

            ///

            var possibleDelimiter = buffer[equals.Length + 1];

            ///
            
            return delimitedBy(possibleDelimiter);
        }
    }

    ///

    public partial class Scanner
    {
        public static bool IsZeroThruTen(
            Char c)
        {
            return c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9'; 
        }

        public static bool IsSpaceOrTabs(
            Char c)
        {
            return c == ' ' || c == '\t';
        }
    }
}