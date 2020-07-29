using DirectSupply.Anonymize.Service.Caching;
using DirectSupply.Anonymize.Service.Constants;
using DirectSupply.Anonymize.Service.Helpers;
using DirectSupply.Anonymize.Service.Models;
using DirectSupply.Anonymize.Service.Utilities;
using System.Collections.Generic;

namespace DirectSupply.Anonymize.Service
{
    public class StoryRetrievalService
    {

        private static readonly NamesCache namesCache = new NamesCache();
        private static readonly StoriesCache storiesCache = new StoriesCache();

        public static List<string> GetStories()
        {
            List<string> stories;
            
            if (storiesCache.ContainsKey(SiteConstants.StoryUrl))
            {
                stories = (List<string>)storiesCache.GetItem(SiteConstants.StoryUrl);
            }
            else
            {
                stories = StoryRetrievalHelper.RetrieveStories(SiteConstants.StoryUrl);
                storiesCache.AddItem(SiteConstants.StoryUrl, stories);
            }

            return stories;
        }

        public static string GetStory(List<string> stories, int storyId)
        {
            string story = StoryRetrievalHelper.RetrieveStory(stories, storyId);

            return story;
        }

        public static List<FullName> GetNamesFromStory(string story, int storyId)
        {
            List<FullName> fullNames;


            if (namesCache.ContainsKey(storyId.ToString()))
            {
                fullNames = (List<FullName>)namesCache.GetItem(storyId.ToString());
            }
            else
            {
                fullNames = FullNameHelper.GetFullNamesFromStory(story);
                namesCache.AddItem(storyId.ToString(), fullNames);
            }            

            return fullNames;
        }

        public static string AnonymizeStory(string story, List<FullName> names)
        {
            string anonymizedStory = NameChanger.ChangeNames(story, names);

            return anonymizedStory;
        }
    }
}
