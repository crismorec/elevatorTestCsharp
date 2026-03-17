using ElevatorSystem.Models;
using ElevatorSystem.Services;

namespace ElevatorSystem
{
    class Program
    {
        static async Task Main()
        {
            var config = new SystemConfiguration();
            var cts = new CancellationTokenSource();
            var manager = new SystemManager(config);

            // Handle clean shutdown for prod-like feel
            Console.CancelKeyPress += (s, e) => {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                manager.StartAll(cts.Token);

                // Start with some calls for immediate test [cite: 10]
                manager.Dispatch(3, Direction.Up);
                manager.Dispatch(9, Direction.Down);

                // Task for random call generation [cite: 10]
                _ = Task.Run(async () => {
                    var rng = new Random();
                    while (!cts.Token.IsCancellationRequested)
                    {
                        await Task.Delay(15000, cts.Token);
                        manager.Dispatch(rng.Next(1, 11), (Direction)rng.Next(1, 3));
                    }
                }, cts.Token);

                while (!cts.Token.IsCancellationRequested)
                {
                    manager.Render();
                    await Task.Delay(1000, cts.Token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal crash: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("System Offline safely.");
            }
        }
    }
}