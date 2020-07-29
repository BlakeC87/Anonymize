using System.Collections.Generic;

namespace DirectSupply.Anonymize.API.Models
{
    /// <summary>
    /// An object that contains information related to a set of stories
    /// </summary>
    public class GetStoriesResponse
    {
        /// <summary>
        /// A list of stories
        /// </summary>
        public List<Story> Stories { get; set; }
    }
}