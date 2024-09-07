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

namespace StockManager3
{
    public partial class Dashboard : Form
    {
        private LoginScreen loginScreen;

        public Dashboard(LoginScreen loginScreen)
        {
            InitializeComponent();
            this.loginScreen = loginScreen;

            LoadChartData();
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

        //graph typshi

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
                string query = "SELECT total, total_sprice, profit, created_at FROM bills";

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        salesData.Add(new SalesData
                        {
                            Total = reader.GetDecimal(0),
                            TotalSupplierPrice = reader.GetDecimal(1),
                            Profit = reader.GetDecimal(2),
                            CreatedAt = reader.GetDateTime(3)
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



}
}

