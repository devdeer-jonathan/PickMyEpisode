using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Logic
{
    using Models;

    public interface ITelevisionShowLogic
    {
        /// <summary>
        /// Gets a collection of television shows based on the <see cref="searchQuery" />.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        /// <returns>A collection of television shows associated with the <see cref="searchQuery" />.</returns>
        Task<IEnumerable<ShowResultModel>> SearchTvShowByNameAsync(string searchQuery);
    }
}
