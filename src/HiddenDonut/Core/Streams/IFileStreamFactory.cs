using System.IO;

namespace HiddenDonut.Core.Streams
{
    internal interface IFileStreamFactory
    {
        Stream Create(string path, FileMode mode, FileAccess access);
    }
}
