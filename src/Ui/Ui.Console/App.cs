using Microsoft.Extensions.Logging;

namespace Ui.Console
{
    using Console = System.Console;

    /// <summary>
    /// Contains the application code for the console app.
    /// </summary>
    public class App
    {
        private readonly ILogger<App> _logger;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="logger">The logger to use.</param>
        public App(ILogger<App> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Represents the program logic of the console app.
        /// </summary>
        /// <param name="args">The command line arguments passed to the app at startup.</param>
        /// <returns>0 if the app ran succesfully otherwise 1.</returns>
        public Task<int> StartAsync(string[] args)
        {
            _logger.LogInformation("Hello from the logger.");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hit any key to exit.");
            Console.ReadKey();
            return Task.FromResult(0);
        }
    }
}