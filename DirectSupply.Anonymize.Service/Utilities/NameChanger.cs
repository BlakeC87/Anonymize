using DirectSupply.Anonymize.Service.Constants;
using DirectSupply.Anonymize.Service.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DirectSupply.Anonymize.Service.Utilities
{
    public class NameChanger
    {
        private static Random random = new Random();

        public static string ChangeNames(string story, List<FullName> fullNames)
        {
            string changedStory = story;

            List<FullName> usedNames = new List<FullName>();

            foreach (FullName fullName in fullNames)
            {
                FullName newName;

                do
                {
                    newName = GetRandomName();
                } while (NameAlreadyUsed(usedNames, newName));

                usedNames.Add(newName);

                changedStory = Regex.Replace(changedStory, fullName.FirstName, newName.FirstName);
                changedStory = Regex.Replace(changedStory, fullName.LastName, newName.LastName);
            }

            return changedStory;
        }

        private static FullName GetRandomName()
        {
            FullName fullName;

            string firstName = GetRandomFirstName();
            string lastName = GetRandomLastName();

            fullName = new FullName(firstName, lastName);

            return fullName;
        }

        private static bool NameAlreadyUsed(List<FullName> usedNames, FullName fullName)
        {
            bool nameUsed = false;

            foreach (FullName usedName in usedNames)
            {
                if (string.Equals(usedName.ToString(), fullName.ToString()))
                {
                    nameUsed = true;
                    break;
                }
            }

            return nameUsed;
        }

        private static string GetRandomFirstName()
        {
            string firstName;

            int nameIndex = random.Next(SampleNames.FirstNames.Count);

            firstName = SampleNames.FirstNames[nameIndex];

            return firstName;
        }

        private static string GetRandomLastName()
        {
            string lastName;

            int nameIndex = random.Next(SampleNames.LastNames.Count);

            lastName = SampleNames.LastNames[nameIndex];

            return lastName;
        }
    }
}
