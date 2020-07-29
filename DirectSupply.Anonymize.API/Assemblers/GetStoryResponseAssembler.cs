using DirectSupply.Anonymize.API.Models;

namespace DirectSupply.Anonymize.API.Assemblers
{
    /// <summary>
    /// Assembles GetStoryResponse objects
    /// </summary>
    public class GetStoryResponseAssembler
    {
        /// <summary>
        /// Assembles a GetStoryResponse object from a story string and a story ID
        /// </summary>
        /// <param name="storyText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GetStoryResponse Assemble(string storyText, int id)
        {
            GetStoryResponse getStoryResponse = new GetStoryResponse();

            getStoryResponse.Story = StoryAssembler.Assemble(storyText, id);

            return getStoryResponse;
        }
    }
}