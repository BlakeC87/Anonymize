using System.Collections.Generic;

namespace DirectSupply.Anonymize.API.Validation
{
    /// <summary>
    /// Contains validation methods relating to a Story ID
    /// </summary>
    public class StoryIdValidation
    {
        /// <summary>
        /// Determines if a Story ID is valid, given a list of stories
        /// </summary>
        /// <param name="stories"></param>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public static bool IsValid(List<string> stories, int storyId)
        {
            bool isValid = false;

            if (storyId > 0 && storyId <= stories.Count)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}