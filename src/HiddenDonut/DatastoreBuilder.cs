using System;
using System.Threading.Tasks;
using HiddenDonut.Logging;

namespace HiddenDonut
{
    public class DatastoreInitializer
    {
        private IDataStore _dataStore;
        private ILogger _logger;
        private IServiceCollection _serviceCollection;

        public async Task Initialize(string name, string path)
        {
            if (_serviceCollection != null)
            {
                throw new InvalidOperationException("Datastore has already been initialized");
            }

            _serviceCollection = new ServiceCollection()
                .RegisterSingleton(_logger ?? new DefaultLogger())
                ;

            _dataStore = _serviceCollection.GetInstance<IDataStore>();

            await _dataStore.Initialize(name, path);
        }

        public DatastoreInitializer WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }
    }
}
