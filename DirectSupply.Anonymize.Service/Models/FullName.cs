using System.Linq;

namespace DirectSupply.Anonymize.Service.Models
{
    public class FullName
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }

        public FullName(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public FullName(string fullName)
        {
            fullName = fullName.Trim();

            if (fullName.Contains(' '))
            {
                string[] splitName = fullName.Split(' ');
                if (splitName.Length > 1)
                {
                    _firstName = splitName[0];
                    _lastName = splitName[1];
                }
            }
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
    }
}
