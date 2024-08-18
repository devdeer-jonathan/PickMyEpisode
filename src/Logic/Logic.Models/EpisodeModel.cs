namespace Logic.Models
{
    /// <summary>
    /// Represents an episode of a show.
    /// </summary>
    public class EpisodeModel
    {
        #region properties

        /// <summary>
        /// The unique identifier of this episode.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The episodes name,
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The season which the episode is part of.
        /// </summary>
        public int Season { get; set; }

        /// <summary>
        /// The episode number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// A short summary of the episodes content.
        /// </summary>
        public string Summary { get; set; } = string.Empty;

        #endregion
    }
}