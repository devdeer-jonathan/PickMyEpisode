namespace Logic.Core
{
    using Interfaces.Logic;
    using Interfaces.Repositories;

    using Models;

    public class TelevisionShowLogic : ITelevisionShowLogic
    {
        /// <inheritdoc />
        public async Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery)
        {
            return await TelevisionShowRepository.SearchTvShowByNameAsync(searchQuery);
        }

        private ITelevisionShowRepository TelevisionShowRepository { get;  }

        public TelevisionShowLogic(ITelevisionShowRepository televisionShowRepository)
        {
            TelevisionShowRepository = televisionShowRepository;
        }
    }
}