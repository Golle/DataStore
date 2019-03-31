using System.Threading.Tasks;

namespace HiddenDonut.Index
{
    internal interface IIndexManager
    {
        ValueTask<IIndexSomething> Initialize(string path, string name);
    }
}