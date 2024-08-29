using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Add this directive here

namespace StockManager3
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void connect_loginscrn_Click(object sender, EventArgs e)
        {
            //check if the text boxes are empty or not

            if (string.IsNullOrEmpty(idtxtbox.Text) || string.IsNullOrEmpty(mdptxtbox.Text))
            {
                MessageBox.Show("Identifier or Password is missing, please try again.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Authentificate The Pass and User using SQL
                string connectionString=""

            }


        }

        //Function to authentificate user using SQL


        private void IDENTIFIANTtxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
