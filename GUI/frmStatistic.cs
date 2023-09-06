using BUS;
using Guna.Charts.WinForms;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmStatistic : Form
    {
        BUS_Bill busBill = new BUS_Bill();

        public frmStatistic()
        {
            InitializeComponent();
        }

        private void chtImportProduct_Load(object sender, EventArgs e)
        {
            Bar(chtImportProduct);
        }

        public void Bar(GunaChart chart)
        {
            //Chart configuration 
            chart.YAxes.GridLines.Display = false;
            chart.Title.Text = "Doanh thu theo tháng";

            //Create a new dataset 
            var dataset = new GunaBarDataset();
            dataset.DataPoints.Add("Tháng 5", busBill.GetRevenueInMay());
            dataset.DataPoints.Add("Tháng 6", busBill.GetRevenueInJune());
            dataset.DataPoints.Add("Tháng 7", busBill.GetRevenueInJuly());

            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart.Update();
        }
    }
}
