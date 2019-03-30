using System;
using System.Threading.Tasks;
using HiddenDonut;
using HiddenDonut.Logging;

namespace HiddenDonutSample1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await new DatastoreInitializer()
                .WithLogger(new ConsoleLogger())
                .Initialize("sample1", "F:/tmp");

            Console.ReadKey();
            //var metadata = new IndexMetadata
            //{
            //    Version = 1,
            //    Date = DateTime.UtcNow.Ticks,
            //    Ids = 0,
            //    Rows = 0
            //};
            //using (var stream = new FileStream(@"f:\tmp\index.es", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //    var metaDataWriter = new IndexMetadataWriter(stream, 0);
            //    var metaDataReader = new IndexMetadataReader(stream, 0);

            //    var stopwatch = Stopwatch.StartNew();
            //    for (uint i = 0; i < 1_000_000; ++i)
            //    {
            //        metadata.Rows = i;
            //        metaDataWriter.Write(in metadata);
            //    }
            //    var count2 = GC.CollectionCount(0);
            //    stopwatch.Stop();

            //    var m = await metaDataReader.Read();
            //    Console.WriteLine($"{m.Version} {m.Date} {m.Ids} {m.Rows}: {stopwatch.Elapsed}");
            //}

            //Console.ReadKey();

        }
    }

    internal class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
