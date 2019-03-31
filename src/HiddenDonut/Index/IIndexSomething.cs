using System;
using System.Threading.Tasks;

namespace HiddenDonut.Index
{
    internal interface IIndexSomething
    {
        ValueTask Append(Guid id, byte[] data);
    }
}