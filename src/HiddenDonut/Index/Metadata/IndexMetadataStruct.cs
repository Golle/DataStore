using System.Runtime.InteropServices;
using HiddenDonut.Constants;

namespace HiddenDonut.Index.Metadata
{
    [StructLayout(LayoutKind.Sequential, Size = ModelSizes.IndexMetaData)]
    internal struct IndexMetadataStruct
    {
        public byte Version;
        public ushort Ids;
        public uint Rows;
        public long Date;
        public uint IndexSize;
    }
}
