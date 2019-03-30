using System.Threading.Tasks;

namespace HiddenDonut.Index
{
    internal interface IIndexFileInitializer
    {
        ValueTask<IIndexFile> CreateOrOpen(string path);
    }
}