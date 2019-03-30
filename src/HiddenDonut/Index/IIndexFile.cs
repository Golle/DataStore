using System;
using System.Threading.Tasks;

namespace HiddenDonut.Index
{
    internal interface IIndexFile : IDisposable
    {
        ValueTask Commit();
    }
}