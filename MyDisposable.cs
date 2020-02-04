using System;

namespace autofac_does_not_dispose
{
    public class MyDisposable : IDisposable
    {
        public void Dispose()
            => WasDisposed = true;

        public bool WasDisposed { get; private set; }
    }
}
