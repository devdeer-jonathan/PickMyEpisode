namespace Logic.Interfaces.Repositories
{
    using Models;

    /// <summary>
    /// Must be implmented by all the repositories handling television show related data access.
    /// </summary>
    public interface ITelevisionShowRepository
    {
        #region methods

        /// <summary>
        /// Gets a collection of episodes which are part of the show with id <see cref="showId" />.
        /// </summary>
        /// <param name="showId">The id of the show to receive episodes for.</param>
        /// <returns>A collection of episodes.</returns>
        Task<IEnumerable<EpisodeModel>> GetEpisodesByShowIdAsync(int showId);

        /// <summary>
        /// Gets a collection of television shows based on the <see cref="searchQuery" />.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        /// <returns>A collection of television shows associated with the <see cref="searchQuery" />.</returns>
        Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery);

        #endregion
    }
}