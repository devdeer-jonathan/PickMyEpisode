namespace Logic.Models
{
    /// <summary>
    /// Represents a TV show as defined for this project.
    /// </summary>
    public class TelevisionShowModel
    {
        #region properties

        /// <summary>
        /// The unique identifier of the show.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the show.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// The date on which the show premiered.
        /// </summary>
        public string? PremierDate { get; set; }

        #endregion
    }
}