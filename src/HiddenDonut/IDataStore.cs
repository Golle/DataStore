using System;
using System.Threading.Tasks;
using HiddenDonut.Constants;

namespace HiddenDonut
{
    public interface IDataStore
    {
        ValueTask Initialize(string name, string path, uint maxIndexSize = DefaultValues.MaxIndexSize);
        ValueTask Append(Guid id, byte[] data);
        ValueTask<byte[]> ReadStream(Guid id);
    }
}
