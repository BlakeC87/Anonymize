using DirectSupply.Anonymize.API.Models;
using System.Collections.Generic;

namespace DirectSupply.Anonymize.API.Assemblers
{
    /// <summary>
    /// Assembles GetStoriesResponse objects
    /// </summary>
    public class GetStoriesResponseAssembler
    {
        /// <summary>
        /// Assembles a GetStoriesResponse object from a list of stories
        /// </summary>
        /// <param name="stories"></param>
        /// <returns></returns>
        public static GetStoriesResponse Assemble(List<string> stories)
        {
            GetStoriesResponse getStoriesResponse = new GetStoriesResponse
            {
                Stories = new List<Story>()
            };

            int storyId = 1;

            foreach (string story in stories)
            {
                getStoriesResponse.Stories.Add(StoryAssembler.Assemble(story, storyId));
                storyId++;
            }

            return getStoriesResponse;
        }
    }
}