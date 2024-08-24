namespace Repositories.TvMaze
{
    using devdeer.Libraries.Abstractions.Interfaces;

    using Logic.Interfaces.Repositories;
    using Logic.Models;
    using Logic.Models.TVMaze;

    public class TelevisionShowRepository : ITelevisionShowRepository
    {
        #region constructors and destructors

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="jsonRestClient">The client to use to call the TV Maze API.</param>
        public TelevisionShowRepository(IJsonRestClient jsonRestClient)
        {
            Client = jsonRestClient;
        }

        #endregion

        #region explicit interfaces

        /// <inheritdoc />
        public async Task<IEnumerable<EpisodeModel>> GetEpisodesByShowIdAsync(int showId)
        {
            var episodeResults =
                await Client.GetAsync<IEnumerable<TvMazeEpisode>>($"shows/{showId}/episodes");
            if (episodeResults == null)
            {
                throw new ArgumentException($"Could not retrieve episodes for show with ID {showId}");
            }
            return episodeResults.Select(
                episodeResult => new EpisodeModel
                {
                    Id = episodeResult.Id,
                    Name = episodeResult.Name,
                    Number = episodeResult.Number,
                    Season = episodeResult.Season,
                    Summary = episodeResult.Summary
                });
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery)
        {
            var showResults =
                await Client.GetAsync<List<TvMazeShowResultModel>>(
                    $"search/shows?q={searchQuery}");
            if (showResults == null)
            {
                throw new ApplicationException("Could not retrieve results from the TV Maze API.");
            }
            return showResults.Select(
                    showResult => new ShowResultModel
                    {
                        Score = showResult.Score,
                        Show = new TelevisionShowModel
                        {
                            Id = showResult.Show.Id,
                            Name = showResult.Show.Name,
                            PremierDate = showResult.Show.PremierDate
                        }
                    })
                .ToList();
        }

        #endregion

        #region properties

        /// <summary>
        /// The client to use to call the TV Maze API.
        /// </summary>
        public IJsonRestClient Client { get; set; }

        #endregion
    }
}
