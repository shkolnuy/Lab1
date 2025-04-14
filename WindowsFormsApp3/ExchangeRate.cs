using System;
using System.Data;
using System.Windows.Forms;
namespace SecondTask
{
    public partial class ExchangeRate : Form
    {
        static string dollarPurchaseMinfinComUa, dollarSaleMinfinComUa,
        euroPurchaseMinfinComUa, euroSaleMinfinComUa;
        static string dollarPurchaseKursComUa, dollarSaleKursComUa, euroPurchaseKursComUa,
        euroSaleKursComUa;

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataCurrencyTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataCurrencyTable)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoadData_Click);
            // 
            // dataCurrencyTable
            // 
            this.dataCurrencyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCurrencyTable.Location = new System.Drawing.Point(102, 52);
            this.dataCurrencyTable.Name = "dataCurrencyTable";
            this.dataCurrencyTable.RowHeadersWidth = 51;
            this.dataCurrencyTable.RowTemplate.Height = 24;
            this.dataCurrencyTable.Size = new System.Drawing.Size(543, 188);
            this.dataCurrencyTable.TabIndex = 1;
            this.dataCurrencyTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCurrencyTable_CellContentClick);
            // 
            // ExchangeRate
            // 
            this.ClientSize = new System.Drawing.Size(848, 435);
            this.Controls.Add(this.dataCurrencyTable);
            this.Controls.Add(this.button1);
            this.Name = "ExchangeRate";
            ((System.ComponentModel.ISupportInitialize)(this.dataCurrencyTable)).EndInit();
            this.ResumeLayout(false);

        }

        static string dollarPurchaseFinanceUa, dollarSaleFinanceUa, euroPurchaseFinanceUa,
        euroSaleFinanceUa;

        private void dataCurrencyTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public ExchangeRate()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }
        private void LoadData_Click(object sender, EventArgs e)
        {
            LoadMinfinComUaData();
            LoadKursComUaData();
            LoadFinanceUaData();
            dataCurrencyTable.DataSource = SetData();
        }
        public static void LoadMinfinComUaData()
        {
            try
            {
                MinfinComUa minfinComUa = new MinfinComUa();
                var dollarMinfinComUa = minfinComUa.GetDollar();
                if (dollarMinfinComUa != null)
                {
                    dollarPurchaseMinfinComUa = dollarMinfinComUa[0];
                    dollarSaleMinfinComUa = dollarMinfinComUa[1];
                }
                var euroMinfinComUa = minfinComUa.GetEuro();
                if (euroMinfinComUa != null)
                {
                    euroPurchaseMinfinComUa = euroMinfinComUa[0];
                    euroSaleMinfinComUa = euroMinfinComUa[1];
                }
              
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void LoadKursComUaData()
        {
            try
            {
                KursComUa kursComUa = new KursComUa();
                var dollarKursKomUa = kursComUa.GetDollar();
                if (dollarKursKomUa != null)
                {
                    dollarPurchaseKursComUa = dollarKursKomUa[0];
                    dollarSaleKursComUa = dollarKursKomUa[1];
                }
                var euroKursKomUa = kursComUa.GetEuro();
                if (euroKursKomUa != null)
                {
                    euroPurchaseKursComUa = euroKursKomUa[0];
                    euroSaleKursComUa = euroKursKomUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void LoadFinanceUaData()
        {
            try
            {
                FinanceUa financeUa = new FinanceUa();
                var dollarFinanceUa = financeUa.GetDollar();
                if (dollarFinanceUa != null)
                {
                    dollarPurchaseFinanceUa = dollarFinanceUa[0];
                    dollarSaleFinanceUa = dollarFinanceUa[1];
                }
                var euroFinanceUa = financeUa.GetEuro();
                if (euroFinanceUa != null)
                {
                    euroPurchaseFinanceUa = euroFinanceUa[0];
                    euroSaleFinanceUa = euroFinanceUa[1];
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.WarningMessage, Properties.Resources.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static DataTable SetData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(Properties.Resources.ResourceColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.CurrencyColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.PurchaseColumnTitle, typeof(string));
            dataTable.Columns.Add(Properties.Resources.SaleColumnTitle, typeof(string));
            dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Dollar,
            dollarPurchaseMinfinComUa, dollarSaleMinfinComUa);
            dataTable.Rows.Add(Properties.Resources.MinfinComUaTitle, Properties.Resources.Euro,
            euroPurchaseMinfinComUa, euroSaleMinfinComUa);
       
            dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Dollar,
            dollarPurchaseKursComUa, dollarSaleKursComUa);
            dataTable.Rows.Add(Properties.Resources.KursComUaTitle, Properties.Resources.Euro,
            euroPurchaseKursComUa, euroSaleKursComUa);
           
            dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Dollar,
            dollarPurchaseFinanceUa, dollarSaleFinanceUa);
            dataTable.Rows.Add(Properties.Resources.FinanceUaTitle, Properties.Resources.Euro,
            euroPurchaseFinanceUa, euroSaleFinanceUa);
          
            return dataTable;
        }

        private Button button1;
        public DataGridView dataCurrencyTable;
    }
}