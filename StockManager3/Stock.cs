using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StockManager3.Stock;

namespace StockManager3
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
            disable_buttons();
        }

        //command prompt
        public class prdctdetails
        {
            public string name { get; set; }
            public string code { get; set; }
            public string description { get; set; }
            public float price { get; set; }
            public float supplier_price { get; set; }
            public int in_stock { get; set; }
            public string supplier { get; set; }
            public string brand { get; set; }
            public float unit { get; set; }
            public string unit_type { get; set; }

        }

        //turns the cmd into prdctdetails
        private prdctdetails fromcmdtoprdct(string[] cmd)
        {
            prdctdetails Product_Details = new prdctdetails
            {
                name = cmd[0].Trim(),
                code = cmd[1].Trim(),
                description = cmd[2].Trim(),
                price = float.Parse(cmd[3].Trim()),
                supplier_price = float.Parse(cmd[4].Trim()),
                in_stock = int.Parse(cmd[5].Trim()),
                supplier = cmd[6].Trim(),
                brand = cmd[7].Trim(),
                unit = float.Parse(cmd[8].Trim()),
                unit_type = cmd[9].Trim()
            };
            return Product_Details;
        }

        //function to check if cmd array is valable
        private string[] checkifcmdisvalable(string[] cmdarray)
        {
            if (cmdarray.Length != 10)
            {
                throw new ArgumentException("Command incomplete, verify that you wrote all product details.");
            }
            else if (cmdarray[0] == "")
            {
                throw new ArgumentException("The product name should be non-null");
            }
            else if (!float.TryParse(cmdarray[3], out _) || !float.TryParse(cmdarray[4], out _) || !float.TryParse(cmdarray[8], out _))
            {
                throw new ArgumentException($"Cannot convert one of the following into a float number : {cmdarray[3]},{cmdarray[4]},{cmdarray[8]}");
            }
            else if (!int.TryParse(cmdarray[5], out _))
            {
                throw new ArgumentException($"Cannot convert one of the following into an int number : {cmdarray[5]}");
            }
            return cmdarray;
        }

        //takes details from the text boxes and put it into an array
        private string[] detailsfromboxes()
        {
            if ((nomtxtbox.Text == "") || (codetxtbox.Text == "") || (descriptiontxtbox.Text == "") || (pricetxtbox.Text == "") || (supplierpricetxtbox.Text == "") || (instocktxtbox.Text == "") || (suppliertxtbox.Text == "") || (brandtxtbox.Text == "") || (unittxtbox.Text == "") || (unittypetxtbox.Text == ""))
            {
                return null;
            }
            string[] cmdarray = {
                nomtxtbox.Text,
                codetxtbox.Text,
                descriptiontxtbox.Text,
                pricetxtbox.Text,
                supplierpricetxtbox.Text,
                instocktxtbox.Text,
                suppliertxtbox.Text,
                brandtxtbox.Text,
                unittxtbox.Text,
                unittypetxtbox.Text
            };
            return cmdarray;
        }

        //add the product from the form
        private prdctdetails addproduct()
        {
            string[] productDetails;
            prdctdetails product;
            try
            {
                //check if cmd box or individual detail boxes is used
                if (commandboxtxtbox.Text != "")
                {
                    productDetails = commandboxtxtbox.Text.Split("<");
                }
                else if (detailsfromboxes() != null)
                {
                    productDetails = detailsfromboxes();
                }
                else
                {
                    throw new ArgumentException($"Text boxes are empty");
                }
                //turn the product details into a product
                product = fromcmdtoprdct(checkifcmdisvalable(productDetails));
                return product;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Cannot add product :(\n{ex.Message}");
            }
            return null;
        }

        private void addprdctintosqldb(prdctdetails product)
        {
            if (product == null)
            {
                return;
            }
            // Define the connection string (replace with your actual DB connection string)
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            // Define the SQL query to insert a new product
            string query = "INSERT INTO products (name, code, description, price, suplier_price, in_stock, suplier, brand, unit, unit_type) " +
                           "VALUES (@name, @code, @description, @price, @supplier_price, @in_stock, @supplier, @brand, @unit, @unit_type)";

            // Use MySqlConnection and MySqlCommand to interact with the database
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        // Add parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@name", product.name);
                        cmd.Parameters.AddWithValue("@code", product.code);
                        cmd.Parameters.AddWithValue("@description", product.description);
                        cmd.Parameters.AddWithValue("@price", product.price);
                        cmd.Parameters.AddWithValue("@supplier_price", product.supplier_price);
                        cmd.Parameters.AddWithValue("@in_stock", product.in_stock);
                        cmd.Parameters.AddWithValue("@supplier", product.supplier);
                        cmd.Parameters.AddWithValue("@brand", product.brand);
                        cmd.Parameters.AddWithValue("@unit", product.unit);
                        cmd.Parameters.AddWithValue("@unit_type", product.unit_type);

                        // Open the connection to the database
                        conn.Open();

                        // Execute the INSERT command
                        cmd.ExecuteNonQuery();
                        if (clearboxescheckbox.Checked)
                        {
                            clearboxes();
                        }

                        MessageBox.Show($"{product.name} Was added successfully");
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

        }

        private void clearboxes()
        {
            nomtxtbox.Text = "";
            codetxtbox.Text = "";
            descriptiontxtbox.Text = "";
            pricetxtbox.Text = "";
            supplierpricetxtbox.Text = "";
            instocktxtbox.Text = "";
            suppliertxtbox.Text = "";
            brandtxtbox.Text = "";
            unittxtbox.Text = "";
            unittypetxtbox.Text = "";
            commandboxtxtbox.Text = "";
        }
        private void addprdctbtn_Click(object sender, EventArgs e)
        {
            //ignore this comment it was just to debug
            //label12.Text = string.Join(",", checkifcmdisvalable(detailsfromboxes()));
            addprdctintosqldb(addproduct());
            LoadDataIntoDataGridView();
        }

        //Data view

        private void LoadDataIntoDataGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            string query = "SELECT id, name, code, description, price, suplier_price, in_stock, suplier, brand, unit, unit_type, created_at FROM products ORDER BY id DESC";
            if (!string.IsNullOrWhiteSpace(searchproducttxtbox.Text))
            {
                query = @"SELECT id, name, code, description, price, suplier_price, in_stock, suplier, brand, unit, unit_type, created_at FROM products
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
                        if (!string.IsNullOrWhiteSpace(searchproducttxtbox.Text))
                        {
                            // Add the parameter for the search term
                            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchproducttxtbox.Text.Trim() + "%");
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

        //Edit product from data view
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && allowdatachange.Checked) // Ensure it's a valid row
            {
                // Retrieve updated value
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                string updatedValue = row.Cells[e.ColumnIndex].Value.ToString();

                // Assuming you have a column in your table that uniquely identifies each row (e.g., "id")
                string productId = row.Cells["id"].Value.ToString();

                // Update the corresponding row in MySQL
                UpdateProductInDatabase(productId, columnName, updatedValue);
            }
        }



        private void UpdateProductInDatabase(string productId, string columnName, string updatedValue)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            // Create the SQL update query
            string query = $"UPDATE products SET {columnName} = @updatedValue WHERE id = @productId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@updatedValue", updatedValue);
                        cmd.Parameters.AddWithValue("@productId", productId);

                        // Execute the update command
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating the database: " + ex.Message);
                }
            }
        }

        //reload the dataview
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            searchproducttxtbox.Text = "";
            LoadDataIntoDataGridView();
        }

        private void allowdatachange_CheckedChanged(object sender, EventArgs e)
        {
            if (allowdatachange.Checked)
            {
                dataGridView1.Cursor = Cursors.Cross;
                dataGridView1.ReadOnly = false;
                //Make these two uneditable
                dataGridView1.Columns["id"].ReadOnly = true;
                dataGridView1.Columns["created_at"].ReadOnly = true;
            }
            else
            {
                dataGridView1.Cursor = Cursors.Default;
                dataGridView1.ReadOnly = true;
            }
        }

        //delete product by ID
        private void deleteproductbtn_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string productname = null;
            //find the product
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM products WHERE id = @id;";

                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //add value
                        cmd.Parameters.AddWithValue("@id", deleteproducttxtbox.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())  // Check if there are results
                            {
                                productname = reader["name"].ToString();  // Get the 'name' column value
                            }
                            else
                            {
                                productname = "[Product name is empty]";  // Handle case where no product is found
                                throw new ArgumentException("Product not found");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }

            // Show confirmation dialog
            DialogResult result = MessageBox.Show($"Are you sure you want to delete this product : {productname} ?",
                                              "Confirm Deletion",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                // Create the SQL query
                string query = "DELETE FROM products WHERE id = @id;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            //add value
                            cmd.Parameters.AddWithValue("@id", deleteproducttxtbox.Text);
                            // Execute the command
                            cmd.ExecuteNonQuery();
                            //disabling and clearing 
                            deleteproducttxtbox.Text = "";
                            disable_buttons();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating the database: " + ex.Message);
                    }
                    LoadDataIntoDataGridView();
                }
            }
        }

        //Show id of highlited product
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a valid row is clicked and the clicked cell is not a header cell
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the DataGridViewRow from the clicked cell
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Assuming 'id' is in the first column
                // Adjust the column index if 'id' is in a different column
                string productId = row.Cells["id"].Value.ToString();

                // Set the id value to the TextBox
                deleteproducttxtbox.Text = productId;
                //abling products
                able_buttons();
            }
        }


        //add empty product
        private void addemptyproductbtn_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            // Create the SQL query
            string query = "INSERT INTO products (name) VALUES ('empty-product')";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating the database: " + ex.Message);
                }
                LoadDataIntoDataGridView();
            }
        }

        private void searchproductbtn_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void searchproducttxtbox_TextChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void searchproducttxtbox_Enter(object sender, EventArgs e)
        {
            //just keep these here until u get how to delete them without breaking the fucking program
        }

        private void searchproducttxtbox_Leave(object sender, EventArgs e)
        {
            //same with this one
        }

        private void duplicateproductbtn_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            prdctdetails product = null;
            string query = null;
            //find the product
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                query = "SELECT * FROM products WHERE id = @id;";

                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //add value
                        cmd.Parameters.AddWithValue("@id", deleteproducttxtbox.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())  // Check if there are results
                            {
                                product = new prdctdetails
                                {
                                    name = reader["name"].ToString(),
                                    code = null,
                                    description = reader["description"].ToString(),
                                    price = float.Parse(reader["price"].ToString()),
                                    supplier_price = float.Parse(reader["suplier_price"].ToString()),
                                    in_stock = int.Parse(reader["in_stock"].ToString()),
                                    supplier = reader["suplier"].ToString(),
                                    brand = reader["brand"].ToString(),
                                    unit = float.Parse(reader["unit"].ToString()),
                                    unit_type = reader["unit_type"].ToString(),
                                };
                            }
                            else
                            {
                                product = new prdctdetails { name = "[Product name is empty]" };  // Handle case where no product is found
                                throw new ArgumentException("Product not found");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
            query = "INSERT INTO products (name, code, description, price, suplier_price, in_stock, suplier, brand, unit, unit_type) " +
                           "VALUES (@name, @code, @description, @price, @supplier_price, @in_stock, @supplier, @brand, @unit, @unit_type)";

            // Use MySqlConnection and MySqlCommand to interact with the database
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        // Add parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@name", product.name);
                        cmd.Parameters.AddWithValue("@code", product.code);
                        cmd.Parameters.AddWithValue("@description", product.description);
                        cmd.Parameters.AddWithValue("@price", product.price);
                        cmd.Parameters.AddWithValue("@supplier_price", product.supplier_price);
                        cmd.Parameters.AddWithValue("@in_stock", product.in_stock);
                        cmd.Parameters.AddWithValue("@supplier", product.supplier);
                        cmd.Parameters.AddWithValue("@brand", product.brand);
                        cmd.Parameters.AddWithValue("@unit", product.unit);
                        cmd.Parameters.AddWithValue("@unit_type", product.unit_type);

                        // Open the connection to the database
                        conn.Open();

                        // Execute the INSERT command
                        cmd.ExecuteNonQuery();
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
            LoadDataIntoDataGridView();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //able_buttons();
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //disable_buttons();
        }

        private void disable_buttons()
        {
            duplicateproductbtn.ForeColor = Color.Gray;
            duplicateproductbtn.Enabled = false;

            deleteproductbtn.ForeColor = Color.Gray;
            deleteproductbtn.Enabled = false;
        }

        private void able_buttons()
        {
            duplicateproductbtn.ForeColor = Color.Black;
            duplicateproductbtn.Enabled = true;

            deleteproductbtn.ForeColor = Color.Black;
            deleteproductbtn.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = checkBox1.Checked;
        }
    }
}
