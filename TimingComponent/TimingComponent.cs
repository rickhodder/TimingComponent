using System;
using System.Timers;

namespace TimingComponent
{
    public class TimingComponent : IDisposable
    {
        protected bool _disposed = false;

        private Timer _timer = new Timer();
        private readonly TimingComponentConfiguration _config;
        private readonly ILogger _logger;

        public TimingComponent(TimingComponentConfiguration config, ILogger logger)
        {
            _config = config;
            _logger = logger;
            _timer.Elapsed += Elapsed;
            _timer.Interval = _config.IntervalInMillseconds;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            Stop();
            Log($"{_config.ServiceName} started processing.");

            _config?.Perform?.Invoke();

            Log($"{_config.ServiceName} finished processing.");
            Start();
        }

        private void Log(string message)
        {
            _logger.Log(message);
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _timer.Stop();
                _timer = null;
                _config.Perform = null; //todo is this necc?
            }

            _disposed = true;

        }
    }
}