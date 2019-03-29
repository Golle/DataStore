using System.Runtime.InteropServices;

namespace HiddenDonut.Models
{
    [StructLayout(LayoutKind.Sequential)]
    internal readonly struct DataRow
    {
        public readonly uint Id;
        public readonly uint Sequence;
        public readonly ulong Offset;
        public readonly ushort Size;
        public readonly ushort Date;
        public DataRow(uint id, uint sequence, ulong offset, ushort size, ushort date)
        {
            Id = id;
            Sequence = sequence;
            Offset = offset;
            Size = size;
            Date = date;
        }
    }
}