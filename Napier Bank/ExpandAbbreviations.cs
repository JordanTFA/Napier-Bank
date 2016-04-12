using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Napier_Bank
{
    // This class will expand any abbreviations (eg. "LOL" becomes "LOL <Laughing out loud")
    class ExpandAbbreviations
    {
        public void expand(string body, string messageID, string Sender)
        {
            // Splits the body and makes an array consisting of each word
            string[] words = body.Split(' ');

            // Read textwords.csv (List of all abbreviations and their expansion
            var sr = new StreamReader(File.OpenRead("../../../Text Words/textwords.csv"));

            // List of abbreviations and expansions
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();

            string newBody = "";

            for (int i = 0; i < words.Length; i++)
            {
                // For each abbreviation, check for a match
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');

                    for (int j = 0; j < words.Length; j++)
                    {
                        listA.Add(values[0]);   // Abbreviation
                        listB.Add(values[1]);   // Expansion

                        // If there's a match, expand the abbreviation
                        if (words[j] == values[0])
                            words[j] = words[j] + "<" + values[1] + ">";
                    }
                }
                // Update body with the expansion
                newBody = newBody + words[i] + " ";
            }

            // Send to class Output to be displayed
            var output = new Output();
            output.Display(newBody, messageID, Sender);
            output.Show();
        }

    }
}
