namespace Ui.Console
{
    using Logic.Interfaces.Logic;
    using Logic.Models;

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
        /// <param name="televisionShowLogic">Injected logic related to TV shows.</param>
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
            tvShows = tvShows.ToList();
            if (!tvShows.Any())
            {
                AnsiConsole.Markup("[red]No shows found matching your search term.[/]\n");
                return 1;
            }
            Console.Clear();
            var selectedShow = AnsiConsole.Prompt(
                new SelectionPrompt<ShowResultModel>().Title("Select a [green]TV show[/] from the list below:")
                    .PageSize(10)
                    .AddChoices(tvShows)
                    .UseConverter(show => $"{show.Show.Name} ({show.Show.PremierDate ?? "N/A"})"));
            Console.Clear();
            AnsiConsole.Markup($"You selected [bold yellow]{selectedShow.Show.Name}[/]!\n");
            var episode = await TelevisionShowLogic.GetRandomEpisodeByShowId(selectedShow.Show.Id);
            DisplayEpisodeDetails(episode);
            Console.ReadKey();
            return 0;
        }

        private static void DisplayEpisodeDetails(EpisodeModel episode)
        {
            Console.Clear();
            AnsiConsole.Markup("[bold yellow]Here's your random episode:[/]\n");
            var panel = new Panel(
                new Markup(
                    $"[bold underline]Season {episode.Season}, Episode {episode.Number}[/]\n\n"
                    + $"[bold green]{episode.Name}[/]\n\n"
                    + $"{(string.IsNullOrEmpty(episode.Summary) ? "[italic grey]No summary available.[/]" : episode.Summary)}"))
            {
                Border = BoxBorder.Rounded,
                Header = new PanelHeader("Random Episode", Justify.Center),
                Padding = new Padding(2, 1)
            };
            AnsiConsole.Write(panel);
            var grid = new Grid().AddColumn()
                .AddColumn();
            grid.AddRow(new Markup("[bold yellow]Season:[/]"), new Markup($"[bold white]{episode.Season}[/]"));
            grid.AddRow(new Markup("[bold yellow]Episode Number:[/]"), new Markup($"[bold white]{episode.Number}[/]"));
            grid.AddRow(new Markup("[bold yellow]Episode Name:[/]"), new Markup($"[bold white]{episode.Name}[/]"));
            AnsiConsole.Write(grid);
            AnsiConsole.Markup("\n[italic grey]Enjoy your episode![/]");
        }

        #endregion

        #region properties

        /// <summary>
        /// Injected logic related to TV shows.
        /// </summary>
        private ITelevisionShowLogic TelevisionShowLogic { get; }

        #endregion
    }
}