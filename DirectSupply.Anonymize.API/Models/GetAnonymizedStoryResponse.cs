namespace DirectSupply.Anonymize.API.Models
{
    /// <summary>
    /// An object that contains information related to a user story
    /// </summary>
    public class GetAnonymizedStoryResponse
    {
        /// <summary>
        /// The story, with people's names randomized
        /// </summary>
        public Story Story { get; set; }
    }
}