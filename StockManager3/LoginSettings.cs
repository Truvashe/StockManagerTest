using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManager3
{
    public partial class LoginSettings : Form
    {
        private LoginScreen loginScreen;
        //Constrcutor to accept instances from loginscreen form
        public LoginSettings(LoginScreen loginScreenInstance)
        {
            InitializeComponent();
            loginScreen = loginScreenInstance;
        }

        

        private void LoginSettingsSaveBtn_Click(object sender, EventArgs e)
        {
            var connectionSettings = new
            {
                server = servernameinput.Text,
                database = dbnameinput.Text,
                userid = useridinput.Text,
                password = pswrdinput.Text
            };

            string json = JsonSerializer.Serialize(connectionSettings);

            if (!File.Exists("ConnectionSettings.json"))
            {
                MessageBox.Show("New connection settings established");
                File.WriteAllText("connectionSettings.json", json);
            }
            else
            {
                MessageBox.Show("Overwriting New connection settings");
                File.WriteAllText("connectionSettings.json", json);
            }
            loginScreen.showlabel();
        }

        

        private void LoginSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
