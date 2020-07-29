using DirectSupply.Anonymize.API.Models;
using DirectSupply.Anonymize.Service.Models;

namespace DirectSupply.Anonymize.API.Assemblers
{
    /// <summary>
    /// Assembles Name objects
    /// </summary>
    public class NameAssembler
    {
        /// <summary>
        /// Assembles a Name object from a FullName service layer object
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static Name Assemble(FullName fullName)
        {
            Name name = new Name();

            name.FirstName = fullName.FirstName;
            name.LastName = fullName.LastName;

            return name;
        }
    }
}