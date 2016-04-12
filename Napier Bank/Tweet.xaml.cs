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
    /// Interaction logic for Tweet.xaml
    /// </summary>
    public partial class Tweet : Window
    {
        public Tweet(string messageID)
        {
            InitializeComponent();
            // Display messageID
            txtMessageID.Text = messageID;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string Sender = txtSender.Text;
            string body = txtBody.Text;
            // RegEx: Sender = "@" followed by 1-15 characters (eg "@EdinburghNapier")
            string sPattern = "^[@]+\\w{1,15}$";

            // RegEx: Sender does not match sPattern
            if (!System.Text.RegularExpressions.Regex.IsMatch(Sender, sPattern))
            {
                // Invalid
                MessageBox.Show("Invalid","Error");
            }

            // Check for mentions ("@Mention")
            checkMentions(body);
            // Check for hashtags ("#Hashtag")
            checkHashtags(body);

            // Get messageID
            string messageID = txtMessageID.Text;

            // Expand Abbreviations
            var Expand = new ExpandAbbreviations();
            Expand.expand(body, messageID, Sender);
            this.Hide();
        }


        public void checkMentions(string body)
        {
            // Splits the body into an array of each word
            string[] words = body.Split(' ');
            // RegEx: Mention = "@text
            string mentionPattern = "^@";

            for (int i = 0; i < words.Length; i++)
            {
                // word matches mentionPattern
                if (System.Text.RegularExpressions.Regex.IsMatch(words[i], mentionPattern))
                {
                    // Send to class Mentions
                    var mention = new Mentions();
                    mention.addMention(words[i]);
                }
            }
        }

        // This will check each word to check if it is a hashtag ("@Hashtag)
        public void checkHashtags(string body)
        {
            // Splits the body into an array of each word
            string[] words = body.Split(' ');
            // RegEx: Hashtag = "#text"
            string hashtagPattern = "^#";

            for (int i = 0; i < words.Length; i++)
            {
                // word matches hashtagPattern
                if (System.Text.RegularExpressions.Regex.IsMatch(words[i], hashtagPattern))
                {
                    // Send to class Hashtags
                    var hashtag = new Hashtags();
                    hashtag.addHashtag(words[i]);
                }
            }
        }

        private void txtBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
