namespace DirectSupply.Anonymize.API.Models
{
    /// <summary>
    /// Contains information relating to a story
    /// </summary>
    public class Story
    {
        /// <summary>
        /// The story ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text of the story
        /// </summary>
        public string StoryText { get; set; }
    }
}