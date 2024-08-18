namespace Logic.Models.TVMaze
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents an episode of a TV show as defined by the TV Maze API.
    /// </summary>
    public class TvMazeEpisode
    {
        #region properties

        /// <summary>
        /// The unique identifier of this episode.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The episodes name,
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// The season which the episode is part of.
        /// </summary>
        [JsonPropertyName("season")]
        public int Season { get; set; }

        /// <summary>
        /// The episode number.
        /// </summary>
        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// A short summary of the episodes content.
        /// </summary>
        [JsonPropertyName("summary")]
        public string Summary { get; set; } = string.Empty;

        #endregion
    }
}