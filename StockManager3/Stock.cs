using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        //command prompt
        public class prdctdetails
        {
            public string name { get ; set; }
            public string code { get; set; }
            public string description { get; set; }
            public float price {  get; set; }
            public float supplier_price { get; set; }
            public int in_stock { get; set; }
            public string supplier {  get; set; }
            public string brand { get; set; }
            public float unit {  get; set; }
            public string unit_type { get; set; }

        }

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
        
        private string[] checkifcmdisvalable(string cmd)
        {
            string[] cmdarray = cmd.Split('<');
            if (cmdarray.Length != 10 )
            {
                throw new ArgumentException("Number of commas should be 10");
            }
            else if (cmdarray[0]=="")
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

        private void addprdctbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] productDetails = checkifcmdisvalable(textBox1.Text);
                for (int i = 0; i < productDetails.Length; i++)
                {
                    productDetails[i] = productDetails[i].Trim();
                }
                string productDetailsString = string.Join(",",productDetails);
                label12.Text = productDetailsString;
            }
            catch (ArgumentException ex)
            {
                    MessageBox.Show($"Cannot add product :(\n{ex.Message}");
            }
            
        }
    }
}
