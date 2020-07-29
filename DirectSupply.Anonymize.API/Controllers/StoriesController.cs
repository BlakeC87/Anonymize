using DirectSupply.Anonymize.API.Assemblers;
using DirectSupply.Anonymize.API.Models;
using DirectSupply.Anonymize.API.Validation;
using DirectSupply.Anonymize.Service;
using DirectSupply.Anonymize.Service.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectSupply.Anonymize.API.Controllers
{
    /// <summary>
    /// Contains actions related to Stories on the Direct Supply website
    /// </summary>
    public class StoriesController : ApiController
    {
        /// <summary>
        /// Retrieves all stories from https://www.directsupply.com/stories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Stories")]
        public GetStoriesResponse GetStories()
        {
            GetStoriesResponse response;

            List<string> stories = RetrieveStories();

            response = GetStoriesResponseAssembler.Assemble(stories);

            return response;
        }

        /// <summary>
        /// Retrieves a specified story from https://www.directsupply.com/stories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Stories/{id}")]
        public GetStoryResponse GetStory(int id)
        {
            GetStoryResponse response;

            string story = RetrieveStory(id);

            response = GetStoryResponseAssembler.Assemble(story, id);

            return response;
        }

        /// <summary>
        /// Retrieves names from a specified story from https://www.directsupply.com/stories
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Stories/{id}/Names")]
        public GetNamesResponse GetNamesFromStory(int id)
        {
            GetNamesResponse response;

            List<FullName> names = RetrieveNamesFromStory(id);

            response = GetNamesResponseAssembler.Assemble(names);

            return response;
        }

        /// <summary>
        /// Retrieves a specified story from https://www.directsupply.com/stories, with names changed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Stories/{id}/AnonymizedStory")]
        public GetAnonymizedStoryResponse GetAnonymizedStory(int id)
        {
            GetAnonymizedStoryResponse response;

            string story = RetrieveAnonymizedStory(id);

            response = GetAnonymizedStoryResponseAssembler.Assemble(story, id);

            return response;
        }

        #region Private Methods

        private List<string> RetrieveStories()
        {
            List<string> stories = StoryRetrievalService.GetStories();

            return stories;
        }

        private string RetrieveStory(int storyId)
        {
            List<string> stories = StoryRetrievalService.GetStories();
            
            AssertValidStoryId(stories, storyId);

            string story = StoryRetrievalService.GetStory(stories, storyId);

            return story;
        }

        private List<FullName> RetrieveNamesFromStory(int storyId)
        {
            List<string> stories = StoryRetrievalService.GetStories();

            AssertValidStoryId(stories, storyId);

            string story = StoryRetrievalService.GetStory(stories, storyId);

            List<FullName> fullNames = StoryRetrievalService.GetNamesFromStory(story, storyId);

            return fullNames;
        }

        private string RetrieveAnonymizedStory(int storyId)
        {
            List<string> stories = StoryRetrievalService.GetStories();

            AssertValidStoryId(stories, storyId);

            string story = StoryRetrievalService.GetStory(stories, storyId);
            List<FullName> names = StoryRetrievalService.GetNamesFromStory(story, storyId);

            string anonymizedStory = StoryRetrievalService.AnonymizeStory(story, names);

            return anonymizedStory;
        }

        /// <summary>
        /// Asserts that the specified storyId is valid, given the stories retrieved
        /// </summary>
        /// <param name="stories"></param>
        /// <param name="storyId"></param>
        private void AssertValidStoryId(List<string> stories, int storyId)
        {
            if (!StoryIdValidation.IsValid(stories, storyId))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No story with ID {0}", storyId)),
                    ReasonPhrase = "Story ID Not Found",
                    StatusCode = HttpStatusCode.NotFound
                };

                throw new HttpResponseException(resp);
            }
        }

        #endregion

    }
}
