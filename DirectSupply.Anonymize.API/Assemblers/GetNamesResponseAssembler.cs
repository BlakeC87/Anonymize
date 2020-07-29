using DirectSupply.Anonymize.API.Models;
using DirectSupply.Anonymize.Service.Models;
using System.Collections.Generic;

namespace DirectSupply.Anonymize.API.Assemblers
{
    /// <summary>
    /// Assembles GetNamesResponse objects
    /// </summary>
    public class GetNamesResponseAssembler
    {
        /// <summary>
        /// Assembles a GetNamesResponse object from a list of FullNames
        /// </summary>
        /// <param name="fullNames"></param>
        /// <returns></returns>
        public static GetNamesResponse Assemble(List<FullName> fullNames)
        {
            GetNamesResponse getNamesResponse = new GetNamesResponse
            {
                Names = new List<Name>()
            };

            foreach (FullName fullName in fullNames)
            {
                getNamesResponse.Names.Add(NameAssembler.Assemble(fullName));
            }

            return getNamesResponse;
        }
    }
}