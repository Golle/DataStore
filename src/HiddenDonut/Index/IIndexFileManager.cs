using System.Threading.Tasks;

namespace HiddenDonut.Index
{
    internal interface IIndexFileManager
    {
        ValueTask Initialize(string name, string path);
    }
}
