using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text.Json;
using System.Windows.Forms;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace StockManager3
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            
            if(File.Exists("ConnectionSettings.json"))
            {
                showlabel();
            }
            else
            {
                checkloginsettingsfile();
            }

            adminlogin();
        }

        public void showlabel()
        {
            string a = BuildConnectionString(ReadDatabaseConfig("ConnectionSettings.json"));
            UpdateConnectionString(a);
            LoginSettingsLabel.Text = a;
            this.Refresh();
        }

        public class DatabaseConfig
        {
            public string server { get; set; }
            public string database { get; set; }
            public string userid { get; set; }
            public string password { get; set; }
        }

        public DatabaseConfig ReadDatabaseConfig(string filepath)
        {
            try
            {
                string json = File.ReadAllText(filepath);
                return JsonSerializer.Deserialize<DatabaseConfig>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public string BuildConnectionString(DatabaseConfig config)
        {
            return $"Server={config.server};Database={config.database};User Id={config.userid};Password={config.password};";
        }

        public void UpdateConnectionString(string connectionString)
        {
            // Open App.config of executable
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Check if the connection string exists
            if (config.ConnectionStrings.ConnectionStrings["MySqlConnection"] != null)
            {
                // If connection string exists, update it
                config.ConnectionStrings.ConnectionStrings["MySqlConnection"].ConnectionString = connectionString;
            }
            else
            {
                // If connection string does not exist, create it
                ConnectionStringSettings settings = new ConnectionStringSettings
                {
                    Name = "MySqlConnection",
                    ConnectionString = connectionString,
                    ProviderName = "MySql.Data.MySqlClient"
                };
                config.ConnectionStrings.ConnectionStrings.Add(settings);
            }

            // Save the changes in App.config file
            config.Save(ConfigurationSaveMode.Modified);

            // Refresh the section to reflect changes in the current session
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private void checkloginsettingsfile()
        {
            var connectionSettings = new
            {
                server = "localhost",
                database = "stock_management",
                userid = "root",
                password = ""
            };

            string json = JsonSerializer.Serialize(connectionSettings);

            if (!File.Exists("ConnectionSettings.json"))
            {
                MessageBox.Show("New connection settings established");
                File.WriteAllText("connectionSettings.json", json);
            }
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
                //mysql connection string : string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
                {
                    try
                    {
                        connection.Open();


                        //we use COUNT(1) to be able to use the command.ExecuteScalar() wich returns only one value in this case we want to return the value of matching username/password
                        string query = "SELECT COUNT(1) FROM users WHERE username = @username AND password = @password";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@username", idtxtbox.Text);
                            command.Parameters.AddWithValue("@password", mdptxtbox.Text);

                            //Convert what command.ExecuteScalar returns into an Int
                            int usercount = Convert.ToInt32(command.ExecuteScalar());

                            if (usercount > 0)
                            {
                                Dashboard dashboard = new Dashboard(this,idtxtbox.Text);
                                Hide();
                                dashboard.ShowDialog(this);
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Login Failed");
                            }
                        }

                    }
                    catch (MySqlException x)
                    {
                        //ERROR from sql
                        MessageBox.Show($"Connection unsuccesfull :(\n{x.Message}");
                    }
                    catch (Exception x)
                    {
                        //ERROR from program
                        MessageBox.Show($"Connection unsuccesfull :(\n{x.Message}");
                    }
                    finally
                    {
                        MessageBox.Show("Connection closed");
                    }
                }

            }


        }

        private void IDENTIFIANTtxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mdptxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginSettings loginSettings = new LoginSettings(this);

            loginSettings.ShowDialog();
        }

        private void adminlogin()
        {
                //Authentificate The Pass and User using SQL
                //mysql connection string : string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
                {
                    try
                    {
                        connection.Open();


                        //we use COUNT(1) to be able to use the command.ExecuteScalar() wich returns only one value in this case we want to return the value of matching username/password
                        string query = "SELECT COUNT(1) FROM users WHERE username = @username AND password = @password";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@username", "mohamed");
                            command.Parameters.AddWithValue("@password", "med");

                            //Convert what command.ExecuteScalar returns into an Int
                            int usercount = Convert.ToInt32(command.ExecuteScalar());

                            if (usercount > 0)
                            {
                                Dashboard dashboard = new Dashboard(this,"mohamed");
                                Hide();
                                dashboard.ShowDialog(this);
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Login Failed");
                            }
                        }

                    }
                    catch (MySqlException x)
                    {
                        //ERROR from sql
                        MessageBox.Show($"Connection unsuccesfull :(\n{x.Message}");
                    }
                    catch (Exception x)
                    {
                        //ERROR from program
                        MessageBox.Show($"Connection unsuccesfull :(\n{x.Message}");
                    }
                    finally
                    {
                        MessageBox.Show("Connection closed");
                    }
                }

            }

    }
}
