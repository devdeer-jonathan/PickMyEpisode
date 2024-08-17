namespace Ui.Console
{
    using Logic.Interfaces.Logic;

    using Microsoft.Extensions.Logging;

    using Spectre.Console;

    using Console = System.Console;

    /// <summary>
    /// Contains the application code for the console app.
    /// </summary>
    public class App
    {
        #region member vars

        private readonly ILogger<App> _logger;

        #endregion

        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="logger">The logger to use.</param>
        public App(ILogger<App> logger, ITelevisionShowLogic televisionShowLogic)
        {
            _logger = logger;
            TelevisionShowLogic = televisionShowLogic;
        }

        #endregion

        #region methods

        /// <summary>
        /// Represents the program logic of the console app.
        /// </summary>
        /// <param name="args">The command line arguments passed to the app at startup.</param>
        /// <returns>0 if the app ran succesfully otherwise 1.</returns>
        public async Task<int> StartAsync(string[] args)
        {
            AnsiConsole.Markup("[bold yellow]Welcome to Pick My Episode![/]\n");
            var searchTerm = AnsiConsole.Ask<string>("Enter a [green]TV show name[/] to search:");
            var tvShows = await TelevisionShowLogic.SearchTvShowByNameAsync(searchTerm);
            tvShows = tvShows.ToArray();
            var table = new Table();
            table.AddColumn("Index");
            table.AddColumn("Show Name");
            table.AddColumn("Premier Date");
            var index = 1;
            foreach (var show in tvShows)
            {
                table.AddRow(index.ToString(), show.Show.Name, show.Show.PremierDate ?? "N/A");
                index++;
            }
            AnsiConsole.Write(table);
            var selectedIndex = AnsiConsole.Prompt(
                new SelectionPrompt<int>().Title("Select a [green]TV show[/] by its index:")
                    .AddChoices(1, tvShows.Count()));
            var selectedShow = tvShows.ToArray()[selectedIndex - 1];
            AnsiConsole.Markup($"You selected [bold yellow]{selectedShow.Show.Name}[/]!\n");
            Console.ReadKey();
            return await Task.FromResult(0);
        }

        #endregion

        #region properties

        private ITelevisionShowLogic TelevisionShowLogic { get; }

        #endregion
    }
}