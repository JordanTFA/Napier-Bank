using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Napier_Bank
{
    class Quarantine
    {
         public void quarURLs(string word)
        {
            using (StreamWriter sw = new StreamWriter("/Uni/Software Engineering/Coursework/SE Coursework/Napier Bank/Quarantined URLs/Quarantined URLs.csv", true))
            {
                sw.WriteLine(word);
            }
        }
    }
}
