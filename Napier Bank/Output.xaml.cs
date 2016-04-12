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
using System.IO;

namespace Napier_Bank
{
    /// <summary>
    /// Interaction logic for Output.xaml
    /// </summary>
    public partial class Output : Window
    {
        MainWindow mw = new MainWindow();
        
        public Output()
        {
            InitializeComponent();
        }

        // Displays all relevant details
        public void Display(string body, string messageID, string Sender)
        {
            txtBody.Text = body;
            txtID.Text = messageID;
            txtSender.Text = Sender;

            // Trending List
            lstTrending.Items.Add("Trending\n");
            // Reads Hashtags.csv
            StreamReader trending = new StreamReader("../../../Twitter/Hashtags.csv");
            // Reads and displays each hashtag
            while (!trending.EndOfStream)
            {
                string line = trending.ReadLine();
                var values = line.Split(',');

                lstTrending.Items.Add(values[0] + " (" +values[1] + ")");
            }

            // Mention List
            lstMentions.Items.Add("Mentions");
            // Reads Mentions.csv
            StreamReader mentions = new StreamReader("../../../Twitter/Mentions.csv");
            // Reads and displays each mention
            while (!mentions.EndOfStream)
            {
                string line = mentions.ReadLine();
                lstMentions.Items.Add(line); 
            }

            // SIR List
            lstSIR.Items.Add("SIR\n");
            // Reads Serious Incident Reports.csv
            StreamReader sir = new StreamReader("../../../Serious Incident Report.csv");
            // Reads and displays each SIR code and report
            while (!sir.EndOfStream) 
            {
                string line = sir.ReadLine();
                var values = line.Split(',');

                lstSIR.Items.Add(values[0]);
                lstSIR.Items.Add(values[1]);
            }

        }
    }
}
