using DirectSupply.Anonymize.API.Models;

namespace DirectSupply.Anonymize.API.Assemblers
{
    /// <summary>
    /// Assembles GetAnonymizedStoryResponse objects
    /// </summary>
    public class GetAnonymizedStoryResponseAssembler
    {
        /// <summary>
        /// Assembles a GetAnonymizedStoryResponse object from a story string and a story ID
        /// </summary>
        /// <param name="storyText"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GetAnonymizedStoryResponse Assemble(string storyText, int id)
        {
            GetAnonymizedStoryResponse getAnonymizedStoryResponse = new GetAnonymizedStoryResponse();

            getAnonymizedStoryResponse.Story = StoryAssembler.Assemble(storyText, id);

            return getAnonymizedStoryResponse;
        }
    }
}