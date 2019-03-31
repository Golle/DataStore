using System.IO;

namespace HiddenDonut.Index
{
    internal class IndexFilePathFormatter : IIndexFilePathFormatter
    {
        public string Format(string path, string name) => Path.Combine(path, $"{name}.esi");
    }
}