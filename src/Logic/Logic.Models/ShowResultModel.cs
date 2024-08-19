namespace Logic.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the result of a show search result.
    /// </summary>
    public class ShowResultModel
    {
        #region properties

        /// <summary>
        /// The score indicating how likely the result is fitting the search query.
        /// </summary>
        [JsonPropertyName("score")]
        public float Score { get; set; }

        /// <summary>
        /// The TV show matching the search query.
        /// </summary>
        [JsonPropertyName("show")]
        public TelevisionShowModel Show { get; set; } = default!;

        #endregion
    }
}
