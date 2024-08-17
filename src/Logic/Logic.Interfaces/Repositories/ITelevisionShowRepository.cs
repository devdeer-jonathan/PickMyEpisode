namespace Logic.Interfaces.Repositories
{
    using Models;

    public interface ITelevisionShowRepository
    {
        #region methods

        /// <summary>
        /// Gets a collection of television shows based on the <see cref="searchQuery" />.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        /// <returns>A collection of television shows associated with the <see cref="searchQuery" />.</returns>
        Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery);

        #endregion
    }
}