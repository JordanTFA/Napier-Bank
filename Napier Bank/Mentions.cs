using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Napier_Bank
{
    //If a mention is found, this class will add it to a mentions file
    class Mentions
    {
        public void addMention(string mention)
        {
            // Writes to Mentions.csv
            using (StreamWriter sw = new StreamWriter("../../../Twitter/Mentions.csv", true))
            {
                sw.WriteLine(mention);
            }
        }
    }
}
