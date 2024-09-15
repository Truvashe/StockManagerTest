using LiveCharts.Wpf;
using LiveCharts;
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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Diagnostics;

namespace StockManager3
{
    public partial class Dashboard : Form
    {
        private LoginScreen loginScreen;
        public string username { get; set; }

        public Dashboard(LoginScreen loginScreen, string username)
        {
            InitializeComponent();
            this.loginScreen = loginScreen;
            this.username = username;

            //MISC
            setupuserandrole();

            //timer
            InitializeTimer();

            //load graphs
            LoadChartData();
            LoadPieChart();
            loadracebar();



        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userlabel_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        //START of misc
        private void setupuserandrole()
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();


                    //we use COUNT(1) to be able to use the command.ExecuteScalar() wich returns only one value in this case we want to return the value of matching username/password
                    string query = "SELECT username,role FROM users WHERE username = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the role from the reader
                                string role = reader["role"].ToString();

                                // Set the text properties of the labels
                                usernamelabel.Text = username;
                                rolelabel.Text = role;
                            }
                            else
                            {
                                // Handle case where no data is returned
                                MessageBox.Show("No user found with the specified username.");
                            }
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

        }

        //END of misc

        //START of graph typshi

        public class SalesData
        {
            public decimal Total { get; set; }
            public decimal TotalSupplierPrice { get; set; }
            public decimal Profit { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public List<SalesData> GetSalesData()
        {
            var salesData = new List<SalesData>();

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT DATE(created_at) AS SaleDate, SUM(total) AS Total, SUM(total_sprice) AS TotalSupplierPrice, SUM(profit) AS Profit FROM bills WHERE created_at >= CURDATE() - INTERVAL 30 DAY GROUP BY SaleDate ORDER BY SaleDate;";

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        salesData.Add(new SalesData
                        {
                            Total = reader.GetDecimal(1),
                            TotalSupplierPrice = reader.GetDecimal(2),
                            Profit = reader.GetDecimal(3),
                            CreatedAt = reader.GetDateTime(0)
                        });
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Handle exception
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Handle exception
                }
            }
            return salesData;
        }

        private void LoadChartData()
        {
            var salesData = GetSalesData();

            // Create Series for each type of data
            var totalSeries = new LineSeries
            {
                Title = "Total Sales",
                Values = new ChartValues<decimal>()
            };

            var profitSeries = new LineSeries
            {
                Title = "Profit",
                Values = new ChartValues<decimal>()
            };

            foreach (var data in salesData)
            {
                totalSeries.Values.Add(data.Total);
                profitSeries.Values.Add(data.Profit);
            }

            // Configure the chart
            cartesianChartventes.Series = new SeriesCollection
                {
                totalSeries,
                profitSeries
                };

            cartesianChartventes.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = salesData.Select(d => d.CreatedAt.ToShortDateString()).ToList()
            });

            cartesianChartventes.AxisY.Add(new Axis
            {
                Title = "Amount",
                LabelFormatter = value => $"{value:0.##} Dh"
            });
        }

        private void LoadPieChart()
        {
            var salesData = GetSalesData();



            decimal totalSupplierPrice = 0;
            decimal profit = 0;


            foreach (var data in salesData)
            {
                totalSupplierPrice += data.TotalSupplierPrice;
                profit += data.Profit;
            }

            decimal total = totalSupplierPrice + profit;

            pieChartProfit.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Supplier Price",
                Values = new ChartValues<decimal> { totalSupplierPrice },
                DataLabels = true,
                LabelPoint = chartPoint => string.Format("{0} ({1:P})", totalSupplierPrice, chartPoint.Participation)
            },
            new PieSeries
            {
                Title = "Profit",
                Values = new ChartValues<decimal> { profit },
                DataLabels = true,
                LabelPoint = chartPoint => string.Format("{0} ({1:P})", profit, chartPoint.Participation)
            }
        };

            pieChartProfit.LegendLocation = LegendLocation.Right;
        }

        public class ProductSales
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int TotalQuantitySold { get; set; }
        }

        public List<ProductSales> GetTop10MostSoldProducts()
        {
            List<ProductSales> productSalesList = new List<ProductSales>();

            using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                connection.Open();
                string query = "SELECT product_id, product_name, SUM(quantity) AS total_quantity_sold FROM bill_items GROUP BY product_id ORDER BY total_quantity_sold DESC LIMIT 10;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productSalesList.Add(new ProductSales
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                TotalQuantitySold = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            return productSalesList;
        }

        private void loadracebar()
        {
            var topProducts = GetTop10MostSoldProducts();
            racebar.Series = new SeriesCollection();

            foreach (var product in topProducts)
            {
                racebar.Series.Add(new RowSeries
                {
                    Title = product.ProductName,
                    Values = new ChartValues<int> { product.TotalQuantitySold },
                    DataLabels = true,
                    LabelPoint = point => $"{product.ProductName}: {product.TotalQuantitySold}",
                });
            }

            //the thing
            var maxQuantity = topProducts.Max(p => p.TotalQuantitySold);
            var minQuantity = topProducts.Min(p => p.TotalQuantitySold);
            var productscount = topProducts.Count();
            var range = maxQuantity - minQuantity;
            var step = Math.Max(1, Math.Round(range / (double)productscount));

            racebar.AxisX.Add(new Axis
            {
                Title = "Quantity Sold",
                LabelFormatter = value => value.ToString("N0"),
                Separator = new Separator
                {
                    Step = step//something using min and max
                }
            });

            racebar.AxisY.Add(new Axis
            {
                Title = "Product",
                LabelFormatter = value => ""

            });

        }

        //END of graphs typshi

        //START of Timer and updated stuff
        private System.Windows.Forms.Timer updateTimer;

        private void InitializeTimer()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000; // Update every second
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        // Timer Tick Event Handler
        // Use this function to put in anything that needs to get updated, the update is happening every second
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            updatedateandtimelabel();
        }

        private void updatedateandtimelabel()
        {
            // Get the current day and time
            string dayName = DateTime.Now.ToString("dddd");
            string formattedDate = DateTime.Now.ToString("dd/MM/yyyy");
            string formattedTime = DateTime.Now.ToString("HH:mm:ss");

            // Capitalize the first letter of the day's name
            string capitalizedDayName = char.ToUpper(dayName[0]) + dayName.Substring(1);

            // Set the text of the date control
            date.Text = $"{capitalizedDayName} {formattedTime}\n{formattedDate}";
        }

        //END of Timer and updated stuff

        //START of clicking buttons

        private void billmakerbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void stockbtn_Click(object sender, EventArgs e)
        {
            Stock stockform = new Stock();

            stockform.Show();
        }
    }
}

