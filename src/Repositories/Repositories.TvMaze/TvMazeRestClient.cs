namespace Repositories.TvMaze
{
    using devdeer.Libraries.RestClient;

    /// <summary>
    /// A preconfigured HTTP client to access the TV Maze API.
    /// </summary>
    public class TvMazeRestClient : JsonRestClient
    {
        /// <inheritdoc />
        public TvMazeRestClient(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}