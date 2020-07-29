using System.Collections.Generic;

namespace DirectSupply.Anonymize.API.Models
{
    /// <summary>
    /// An object that contains information related to people's names found in a story
    /// </summary>
    public class GetNamesResponse
    {
        /// <summary>
        /// A list of names found in the story
        /// </summary>
        public List<Name> Names { get; set; }
    }
}