using System.Buffers;
using System.Buffers.Text;
using System.Text;

namespace SpanUndMemory
{
    public class SpanSample
    {
        void SimplySpan()
        {
            byte[] array = new byte[4];

            Span<byte> span = new Span<byte>(array);
            Span<byte> span2 = array.AsSpan();

            Span<byte> slice1 = span.Slice(start: 1, length: 2);
            Span<byte> slice2 = span.Slice(2, 2);

            ReadOnlySpan<byte> roSpan = array.AsSpan();
        }

        void AccessSpan()
        {
            string[] array = { "a", "b", "c", "d", "e", "f" };

            var firstView = new Span<string>(array, 0, 3); // "a", "b", "c"
            var secondView = new Span<string>(array, 2, 3); // "c", "d", "e"


            firstView[0] = "X";
            // {"X", "b", "c", "d", "e", "f"}

            firstView[2] = "Y";
            // {"X", "b", "Y", "d", "e", "f"}

            secondView[0] = "U";
            // {"X", "b", "U", "d", "e", "f"}

            firstView[20] = "20";
            // IndexOutOfRangeException
        }

        public int ArraySum(byte[] data)
        {
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }

            return sum;
        }

        public int SpanSum(Span<byte> data)
        {
            int sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i];
            }

            return sum;
        }

        public int StringParseSum(string data)
        {
            int sum = 0;
            // allocates memory
            string[] splitString = data.Split(',');
            for (int i = 0; i < splitString.Length; i++)
            {
                sum += int.Parse(splitString[i]);
            }
            return sum;
        }

        public int StringParseSumWithSpan(string data)
        {
            // allocates Memory
            Span<byte> utf8 = Encoding.UTF8.GetBytes(data);
            int sum = 0;
            while (true)
            {
                // Utf8Parser is faster than usual UTF16 strings
                Utf8Parser.TryParse(utf8, out int value, out int bytesConsumed);
                sum += value;
                if (utf8.Length - 1 < bytesConsumed)
                    break;
                // skip ','    
                utf8 = utf8.Slice(bytesConsumed + 1);
            }
            return sum;
        }

        public int StringParseSumWithArrayPool(string data)
        {
            Encoding encode = Encoding.UTF8;
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;

            int minLength = encode.GetByteCount(data);
            byte[] array = pool.Rent(minLength);
            Span<byte> utf8 = array;
            int bytesWritten = encode.GetBytes(data, utf8);
            utf8 = utf8.Slice(0, bytesWritten);

            int sum = 0;
            while (true)
            {
                // Utf8Parser is faster than usual UTF16 strings
                Utf8Parser.TryParse(utf8, out int value, out int bytesConsumed);
                sum += value;
                if (utf8.Length - 1 < bytesConsumed)
                    break;
                // skip ','    
                utf8 = utf8.Slice(bytesConsumed + 1);
            }

            return sum;
        }

        public int HeapAllocReverseArray(int[] data)
        {
            // Heap-allocated array for defensive copy
            int[] array = new int[data.Length];
            Array.Copy(data, array, data.Length);
            Array.Reverse(array);
            return array[0];
        }

        public int UnsafeStackAllocReverse(int[] data)
        {
            unsafe  // unsafe compiling needs to be enabled in  project settings
            {
                // We lose safety and bounds checks
                int* ptr = stackalloc int[data.Length];
                // No APIs available to copy and reverse
                for (int i = 0; i < data.Length; i++)
                {
                    ptr[i] = data[data.Length - i - 1];
                }
                return ptr[0];
            }
        }

        public int SafeStackOrHeapAllocReverse(int[] data)
        {
            // Chose an arbitrary small constant
            Span<int> span = data.Length < 128 ?
                        stackalloc int[data.Length] :
                        new int[data.Length];
            data.CopyTo(span);
            span.Reverse();
            return span[0];
        }
    }
}