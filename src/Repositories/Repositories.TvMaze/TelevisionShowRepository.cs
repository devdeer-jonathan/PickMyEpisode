namespace Repositories.TvMaze
{
    using devdeer.Libraries.Abstractions.Interfaces;

    using Logic.Interfaces.Repositories;
    using Logic.Models;
    using Logic.Models.TVMaze;

    public class TelevisionShowRepository : ITelevisionShowRepository
    {
        #region constructors and destructors

        public TelevisionShowRepository(IJsonRestClient jsonRestClient)
        {
            Client = jsonRestClient;
        }

        #endregion

        #region explicit interfaces

        /// <inheritdoc />
        public async Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery)
        {
            var showResults =
                await Client.GetAsync<List<TvMazeShowResultModel>>(
                    $"https://api.tvmaze.com/search/shows?q={searchQuery}");
            return showResults.Select(
                    showResult => new ShowResultModel()
                    {
                        Score = showResult.Score,
                        Show = new TelevisionShowModel()
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