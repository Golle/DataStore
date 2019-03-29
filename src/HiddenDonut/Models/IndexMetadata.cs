using System.Runtime.InteropServices;

namespace HiddenDonut.Models
{
    [StructLayout(LayoutKind.Sequential, Size = ModelSizes.IndexMetaData)]
    internal struct IndexMetadata
    {
        public byte Version;
        public ushort Ids;
        public uint Rows;
        public long Date;
    }
}
