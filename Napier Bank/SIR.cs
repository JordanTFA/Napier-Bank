using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Napier_Bank
{
    //If the e-mail is an SIR, it will add the SIR code and the report to a file
    class SIR
    {
        public void getSIR(string SIR, string report)
        {
            // Writes to Serious Incident Report.csv
            using (StreamWriter sw = new StreamWriter("../../../Serious Incident Report.csv", true))
            {
                // SIR, report
                sw.WriteLine(SIR + "," + report);
            }
        }
    }
}
