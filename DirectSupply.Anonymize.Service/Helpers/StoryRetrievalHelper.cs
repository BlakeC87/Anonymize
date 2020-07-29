using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace DirectSupply.Anonymize.Service.Helpers
{
    public class StoryRetrievalHelper
    {
        public static List<string> RetrieveStories(string url)
        {
            List<string> stories = new List<string>();

            HtmlDocument doc = new HtmlWeb().Load(url);

            IEnumerable<HtmlNode> storyNodes = doc.DocumentNode.Descendants("div")
                .Where(div => div.HasClass("custom-post-content-container"));

            List<HtmlNode> storyTextNodes = BuildStoryNodeList(storyNodes);

            foreach (HtmlNode storyTextNode in storyTextNodes)
            {
                stories.Add(storyTextNode.InnerText);
            }

            return stories;
        }

        public static string RetrieveStory(List<string> stories, int id)
        {
            string story = stories[id - 1];

            return story;
        }

        private static List<HtmlNode> BuildStoryNodeList(IEnumerable<HtmlNode> storyNodes)
        {
            List<HtmlNode> storyTextNodes = new List<HtmlNode>();

            foreach (HtmlNode storyNode in storyNodes)
            {
                storyTextNodes.Add(storyNode.Descendants("p").First());
            }

            return storyTextNodes;
        }
    }
}
