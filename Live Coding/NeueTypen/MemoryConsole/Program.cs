using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanMemoryConsole
{
    internal class MemoryWithoutOwner
    {
        static void Main()
        {
            Memory<char> memory = new char[64];

            Console.Write("Enter a number: ");
            var value = Int32.Parse(Console.ReadLine());

            WriteInt32ToBuffer(value, memory);
            DisplayBufferToConsole(memory);
        }

        static void WriteInt32ToBuffer(int value, Memory<char> buffer)
        {
            var strValue = value.ToString();
            strValue.AsSpan().CopyTo(buffer.Slice(0, strValue.Length).Span);
        }

        static void DisplayBufferToConsole(Memory<char> buffer) =>
            Console.WriteLine($"Contents of the buffer: '{buffer}'");
    }
}
