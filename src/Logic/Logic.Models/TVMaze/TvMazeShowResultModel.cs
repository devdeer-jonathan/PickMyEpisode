namespace Logic.Models.TVMaze
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the result of a show search result as defined by the TV Maze API.
    /// </summary>
    public class TvMazeShowResultModel
    {
        #region properties

        /// <summary>
        /// The score indicating how likely the result is fitting the search query.
        /// </summary>
        [JsonPropertyName("score")]
        public float Score { get; set; }

        /// <summary>
        /// The tv show matching the search query.
        /// </summary>
        [JsonPropertyName("show")]
        public TvMazeTelevisionShowModel Show { get; set; } = default!;

        #endregion
    }
}