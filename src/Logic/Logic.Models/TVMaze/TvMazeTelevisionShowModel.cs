namespace Logic.Models.TVMaze
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a television show as defined by TVMaze API.
    /// </summary>
    public class TvMazeTelevisionShowModel
    {
        #region properties

        /// <summary>
        /// The unique identifier of the show.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the show.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// The date on which the show premiered.
        /// </summary>
        [JsonPropertyName("premiered")]
        public string? PremierDate { get; set; }

        #endregion
    }
}