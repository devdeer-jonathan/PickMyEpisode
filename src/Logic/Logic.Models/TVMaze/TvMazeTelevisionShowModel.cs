namespace Logic.Models.TVMaze
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a television show as defined by TVMaze API.
    /// </summary>
    public class TvMazeTelevisionShowModel
    {
        #region properties

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("premiered")]
        public string? PremierDate { get; set; }

        #endregion
    }
}