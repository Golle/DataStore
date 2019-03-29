using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using HiddenDonut.Models;
using HiddenDonut.Writer;

namespace HiddenDonutSample1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var metadata = new IndexMetadata
            {
                Version = 1,
                Date = DateTime.UtcNow.Ticks,
                Ids = 0,
                Rows = 0
            };
            using (var stream = new FileStream(@"d:\private\tmp\index.es", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var metaDataWriter = new IndexMetadataWriter(stream, 0);
                var metaDataReader = new IndexMetadataReader(stream, 0);

                var stopwatch = Stopwatch.StartNew();
                var count = GC.CollectionCount(0);
                for (uint i = 0; i < 1_000_000; ++i)
                {
                    metadata.Rows = i;
                    metaDataWriter.Write(in metadata);
                }
                var count2 = GC.CollectionCount(0);
                Console.WriteLine($"{count} {count2}");
                stopwatch.Stop();

                var m = await metaDataReader.Read();
                Console.WriteLine($"{m.Version} {m.Date} {m.Ids} {m.Rows}: {stopwatch.Elapsed}");
            }

            
        }
    }
}
