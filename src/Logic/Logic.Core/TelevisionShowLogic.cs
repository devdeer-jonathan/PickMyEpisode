namespace Logic.Core
{
    using Interfaces.Logic;
    using Interfaces.Repositories;

    using Models;

    public class TelevisionShowLogic : ITelevisionShowLogic
    {
        #region constructors and destructors

        /// <summary>
        /// Default ctor.
        /// </summary>
        /// <param name="televisionShowRepository">The repository to access TV show data.</param>
        public TelevisionShowLogic(ITelevisionShowRepository televisionShowRepository)
        {
            TelevisionShowRepository = televisionShowRepository;
        }

        #endregion

        #region explicit interfaces

        /// <inheritdoc />
        public async Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery)
        {
            return await TelevisionShowRepository.SearchTvShowByNameAsync(searchQuery);
        }

        #endregion

        #region methods

        public async Task<EpisodeModel> GetRandomEpisodeByShowId(int showId)
        {
            var episodes = await TelevisionShowRepository.GetEpisodesByShowIdAsync(showId);
            episodes = episodes.ToArray();
            if (episodes == null)
            {
                throw new ApplicationException($"Could not retrieve any episodes for show with id {showId}");
            }
            var random = new Random();
            var randomEpisode = episodes.ToArray()[random.Next(0, episodes.Count() - 1)];
            return randomEpisode;
        }

        #endregion

        #region properties

        /// <summary>
        /// The repository to access TV show data.
        /// </summary>
        private ITelevisionShowRepository TelevisionShowRepository { get; }

        #endregion
    }
}