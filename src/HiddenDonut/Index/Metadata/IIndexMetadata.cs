using System;

namespace HiddenDonut.Index.Metadata
{
    internal interface IIndexMetadata : IDisposable
    {
        void IncreaseRows();
        uint IndexOf(in Guid id);
    }
}