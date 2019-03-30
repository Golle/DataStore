using System.IO;

namespace HiddenDonut.Core.Streams
{
    internal class FileStreamFactory : IFileStreamFactory
    {
        public Stream Create(string path, FileMode mode, FileAccess access)
        {
            return new FileStream(path, mode, access, FileShare.ReadWrite);
        }
    }
}