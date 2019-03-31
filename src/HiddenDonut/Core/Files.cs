namespace HiddenDonut.Core
{
    internal class Files : IFiles
    {
        public bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }
    }
}