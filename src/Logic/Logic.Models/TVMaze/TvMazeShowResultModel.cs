namespace Logic.Models.TVMaze
{
    using System.Text.Json.Serialization;

    public class TvMazeShowResultModel
    {
        #region properties

        [JsonPropertyName("score")]
        public float Score { get; set; }

        [JsonPropertyName("show")]
        public TvMazeTelevisionShowModel Show { get; set; } = default!;

        #endregion
    }
}