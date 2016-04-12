using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Napier_Bank
{
    // This class will add any hashtags to a hashtag.csv file, and is it exists, add a counter to show trending hashtags
    // TODO: Fix the counter
    class Hashtags
    {
        public void addHashtag(string hashtag)
        {
            //List of hashtag and its corresponding count
            var hash = new List<string>();
            var count = new List<string>();

            // Read Hashtags.csv
            string path = "../../../Twitter/Hashtags.csv";
            using (var sr = new StreamReader(File.OpenRead(path)))
            {
                string line;

                // For each line in hashtag.csv
                while ((line = sr.ReadLine()) != null)
                {
                    // Add to an array
                    var values = line.Split(',');
                    hash.Add(values[0]);
                    count.Add(values[1]);
                }
            }

            // Create array, and add the hashtag and its count
            string[] hashtagArray = hash.ToArray();
            string[] countArray = count.ToArray();

            // Write to Hashtags.csv
            using (StreamWriter sw = new StreamWriter("../../../Twitter/Hashtags.csv", true))
            {
                for (int i = 0; i < hashtagArray.Length; i++)
                {
                    // If the hashtag is already in the file
                    if (hashtag == hashtagArray[i])
                    {
                        // Add 1 to its count and write a new line with the new line
                        int toAdd = int.Parse(countArray[i]) + 1;
                        sw.WriteLine(hashtag + ',' + toAdd);
                    }
                }
                sw.WriteLine(hashtag + ',' + "1");
            }
        }
    }
}
