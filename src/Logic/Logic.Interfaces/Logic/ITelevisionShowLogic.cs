namespace Logic.Interfaces.Logic
{
    using Models;

    /// <summary>
    /// Must be implemented by all logic regarding shows.
    /// </summary>
    public interface ITelevisionShowLogic
    {
        #region methods

        /// <summary>
        /// Gets a random episode from the show specified by the <see cref="showId" />.
        /// </summary>
        /// <param name="showId">The unique identifier of the show.</param>
        /// <returns>The randomly chosen episode of the show.</returns>
        Task<EpisodeModel> GetRandomEpisodeByShowId(int showId);

        /// <summary>
        /// Gets a collection of television shows based on the <see cref="searchQuery" />.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        /// <returns>A collection of television shows associated with the <see cref="searchQuery" />.</returns>
        Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery);

        #endregion
    }
}