using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Logging;

namespace HiddenDonut.Index
{
    internal class IndexFileManager : IIndexFileManager
    {
        private readonly IIndexFileInitializer _indexFileInitializer;
        private readonly ILogger _logger;

        public IndexFileManager(IIndexFileInitializer indexFileInitializer, ILogger logger)
        {
            _indexFileInitializer = indexFileInitializer;
            _logger = logger;
        }

        public async ValueTask Initialize(string name, string path)
        {
            _logger.Log("Initialize IndexFile");
            var indexFile = await _indexFileInitializer.CreateOrOpen(Path.Combine(path, $"{name}.ies"));
            await Task.CompletedTask;
        }
    }
}