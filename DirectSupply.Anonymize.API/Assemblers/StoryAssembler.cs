using DirectSupply.Anonymize.API.Models;

namespace DirectSupply.Anonymize.API.Assemblers
{
    /// <summary>
    /// Assembles Story objects
    /// </summary>
    public class StoryAssembler
    {
        /// <summary>
        /// Assembles a Story object from a story string and a story ID
        /// </summary>
        /// <param name="storyText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Story Assemble(string storyText, int id)
        {
            Story story = new Story
            {
                Id = id,
                StoryText = storyText
            };

            return story;
        }
    }
}