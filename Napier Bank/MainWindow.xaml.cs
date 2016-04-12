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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string messageID;

        public string MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }
        private void btnID_Click(object sender, RoutedEventArgs e)
        {
            messageID = txtID.Text;
            string idPattern = "^[Ss|Ee|Tt]+\\d{9}$";   // Either S, E or T followed by 9 digits (eg. E123456789)

            // RegEx: messageID matches idPattern (Message ID)
            if (System.Text.RegularExpressions.Regex.IsMatch(messageID, idPattern)) 
            {
                // Gets first character of messageID
                string messageType = messageID.Substring(0, 1); 

                // SMS
                if (messageType == "S" || messageType == "s")
                {
                    var SMS = new SMS(messageID);
                    SMS.Show();
                    this.Hide();
                }

                // E-Mail
                else if (messageType == "E" || messageType == "e")
                {
                    var Email = new Email(messageID);
                    Email.Show();
                    this.Hide();
                }

                // Twitter
                else if (messageType == "T" || messageType == "t")
                {
                    var Tweet = new Tweet(messageID);
                    Tweet.Show();
                    this.Hide();
                }

            }
            else
                MessageBox.Show("Invalid","Error"); // Invalid


        }
    }
}
