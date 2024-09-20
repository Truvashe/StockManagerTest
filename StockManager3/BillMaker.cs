using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManager3
{
    public partial class BillMaker : Form
    {
        public BillMaker()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "SELECT name, code, description, price FROM products ORDER BY id DESC";
            if (!string.IsNullOrWhiteSpace(billsearchproducttxtbox.Text))
            {
                query = @"SELECT name, code, description, price FROM products
                  WHERE id LIKE @searchTerm
                  OR name LIKE @searchTerm
                  OR brand LIKE @searchTerm
                  OR suplier LIKE @searchTerm
                  OR description LIKE @searchTerm
                  OR code LIKE @searchTerm
                  ORDER BY id DESC;";
            }

            // Use a DataTable to store the query results
            DataTable dataTable = new DataTable();

            // Connect to the MySQL database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(billsearchproducttxtbox.Text))
                        {
                            // Add the parameter for the search term
                            cmd.Parameters.AddWithValue("@searchTerm", "%" + billsearchproducttxtbox.Text.Trim() + "%");
                        }

                        // Use MySqlDataAdapter to fill the DataTable
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;

                        //on readonly to prevent from wrong manipulation
                        dataGridView1.ReadOnly = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Loading data: " + ex.Message);
                }
            }
        }

        private void billsearchproducttxtbox_TextChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
    }
}
