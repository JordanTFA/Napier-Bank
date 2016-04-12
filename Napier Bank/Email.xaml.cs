using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Napier_Bank
{
    /// <summary>
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Window
    {
        public Email(string messageID)
        {
            InitializeComponent();
            // Display messageID
            txtMessageID.Text = messageID;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string Sender = txtSender.Text;
            string subject = txtSubject.Text;
            string body = txtBody.Text;

            // RegEx: Sender = e-mail address (eg. "40136554@Napier.ac.uk")
            string senderPattern = @"^[A-Z0-9a-z._ % +-]+@[A-Z0-9a-z.-]+\.[A-Za-z]{2,}$";
            // RegEx: Subject (SIR) = format "SIR dd-mm-yy" (eg. "SIR 23/04/15")
            string SIRPattern = "^[S|s]+[I|i]+[R|r]+ \\d{2}/\\d{2}/\\d{2}$";

            // RegEx: Sender matches senderPattern
            if (System.Text.RegularExpressions.Regex.IsMatch(Sender, senderPattern))
            {
                // RegEx: subject matches SIRPattern
                if (System.Text.RegularExpressions.Regex.IsMatch(subject, SIRPattern))
                {
                    // RegEx: SIR = format "dd-dd-dd" (eg. 12-34-56)
                    string sirPattern = "^\\d{2}-\\d{2}-\\d{2}$";

                    // Reads first line of txtBody, saves as string (SIR)
                    string SIR = txtBody.GetLineText(0).Replace("\n", String.Empty).Replace("\r", String.Empty);


                    // RegEx: Report = Alphabetical characters (eg. "Theft" or "Armed Robbery")
                    string reportPattern = "^[A-Za-z]";

                    // Reads second line of txtBody, saves as string (report)
                    string report = txtBody.GetLineText(1).Replace("\n", String.Empty).Replace("\r", String.Empty);

                    // RegEx: SIR matches sirPattern AND report matches reportPattern
                    if ((System.Text.RegularExpressions.Regex.IsMatch(SIR, sirPattern)) && (System.Text.RegularExpressions.Regex.IsMatch(report, reportPattern)))
                    {
                        // Send to class "SIR"
                        var SIRList = new SIR();
                        SIRList.getSIR(SIR, report);


                    }
                    else
                    {
                        // Invalid 
                        MessageBox.Show("Invalid input", "Error");
                    }
                }
                // Check for URLs
                checkQuar(body);
            }
        }


            // This checks for any URLs in the body, if it finds a url, it sends it to the Quarantine class
            // to write it to a Quarantine list, and then will replace the URL with "<URL Removed>"
            public void checkQuar(string body)
            {
                // Splits the body into an array of each word
                string[] words = body.Split(' ');
                // RegEx: URL (eg. "www.napier.ac.uk" or "http://napier.ac.uk" or "https://napier.ac.uk" etc)
                string urlPattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

                string newBody = "";

                for (int i = 0; i < words.Length; i++)
                {
                    // RegEx: word matches URL
                    if (System.Text.RegularExpressions.Regex.IsMatch(words[i], urlPattern))
                    {
                        // Send to class Quarantine to be added to Quarantine list
                        var quarantine = new Quarantine();
                        quarantine.quarURLs(words[i]);

                        // Replace URL
                        words[i] = "<URL Removed>";
                    }

                    // Create a new body with urls replaced
                    newBody = newBody + words[i] + " ";
                }

                string messageID = txtMessageID.Text;
                string Sender = txtSender.Text;

                // Send to class Output to be displayed
                var output = new Output();
                output.Display(newBody, messageID, Sender);

                output.Show();
                this.Hide();
            }
    }
}