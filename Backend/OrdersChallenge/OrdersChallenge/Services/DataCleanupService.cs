using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace OrdersChallenge.Services
{
    public class DataCleanupService : IHostedService, IDisposable
    {
        private Timer? _limpiador;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Cada x tiempo
            _limpiador = new Timer(ClearDataStorage, null, TimeSpan.Zero, TimeSpan.FromHours(2));
            return Task.CompletedTask;
        }

        private void ClearDataStorage(object state)
        {
            OrdersDataStorage.OrdersDs.OrdersCollection.Clear();
            //Console.WriteLine($"Probando limpieza de la colección: [{DateTime.Now}]");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _limpiador?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _limpiador?.Dispose();
        }
    }
}
