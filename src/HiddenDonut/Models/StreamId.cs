using System;
using System.Runtime.InteropServices;

namespace HiddenDonut.Models
{
    [StructLayout(LayoutKind.Sequential, Size = 144)]
    internal readonly struct StreamId
    {
        public readonly Guid Id;
        //public readonly ushort KeyIndex;
        public StreamId(in Guid id)
        {
            Id = id;
        }
    }
}