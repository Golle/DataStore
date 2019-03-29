using System.Runtime.InteropServices;

namespace HiddenDonut.Models
{
    [StructLayout(LayoutKind.Sequential, Size = 1024)]
    internal struct DataMetadata
    {
        public byte Version;
        public DataMetadata(byte version)
        {
            Version = version;
        }
    }
}