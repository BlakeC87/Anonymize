using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DirectSupply.Anonymize.Service.Constants;
using DirectSupply.Anonymize.Service.Models;
using edu.stanford.nlp.ie.crf;

namespace DirectSupply.Anonymize.Service.Helpers
{
    public class FullNameHelper
    {
        public static List<FullName> GetFullNamesFromStory(string story)
        {
            List<FullName> fullNames = new List<FullName>();

            string results = GetNLPResults(story);

            MatchCollection nameMatches = Regex.Matches(results, ClassifierPatterns.NamePattern);

            List<string> nameList = new List<string>();

            foreach (Match nameMatch in nameMatches)
            {
                string name = Regex.Replace(nameMatch.Value, ClassifierPatterns.NameTagPattern, string.Empty);

                // The NER analysis has trouble with back-to-back names separated by a comma. We will have to split them manually.
                if (name.Contains(","))
                {
                    string[] names = name.Split(',');
                    nameList.AddRange(names);
                }
                else
                {
                    nameList.Add(name);
                }
            }

            foreach (string name in nameList)
            {
                if (name.Contains(' '))
                {
                    FullName fullName = new FullName(name);
                    fullNames.Add(fullName);
                }
            }

            return fullNames;
        }

        private static string GetNLPResults(string story)
        {
            string results;

            // Path to the folder with classifiers models
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string classifiersDirectory = baseDirectory + @"..\DirectSupply.Anonymize.Service\Models\NLP";

            // Loading 3 class classifier model
            CRFClassifier classifier = CRFClassifier.getClassifierNoExceptions(
                classifiersDirectory + @"\english.all.3class.distsim.crf.ser.gz");

            results = classifier.classifyWithInlineXML(story);

            return results;
        }
    }
}
