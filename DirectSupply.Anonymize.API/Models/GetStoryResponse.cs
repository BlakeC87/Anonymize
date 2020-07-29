namespace DirectSupply.Anonymize.API.Models
{
    /// <summary>
    /// An object that contains information related to a specified story
    /// </summary>
    public class GetStoryResponse
    {
        /// <summary>
        /// The specified story
        /// </summary>
        public Story Story { get; set; }
    }
}