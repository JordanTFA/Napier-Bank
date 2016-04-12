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
using System.Windows.Shapes;

namespace Napier_Bank
{
    /// <summary>
    ///// Interaction logic for SMS.xaml
    /// </summary>
    public partial class SMS : Window
    {
        public SMS(string messageID)
        {
            InitializeComponent();
            // Display messageID
            txtMessageID.Text = messageID;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // This must be a phone number. Note that it is a string instead a numeric
            // variable.
            string Sender = txtSender.Text;

            // RegEx: Sender = 5 digits, followed by a dash, followed by 6 digits (eg. 12345-123456)
            string sPattern = "^\\d{5}-\\d{6}$";    

            // RegEx: Sender matches sPattern
            if(System.Text.RegularExpressions.Regex.IsMatch(Sender, sPattern))
            {
                string body = txtBody.Text;
                string messageID = txtMessageID.Text;

                // Expand abbreviations
                var Expand = new ExpandAbbreviations();
                Expand.expand(body, messageID, Sender);
                this.Hide();
            }
            else
                MessageBox.Show("Please enter a valid phone number","Error");   // Invalid phone number



        }
    }
}
