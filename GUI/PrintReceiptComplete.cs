using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULs;

namespace GUI
{
    public partial class PrintReceiptComplete : UserControl
    {
        
        private static PrintReceiptComplete _instance;
        public static PrintReceiptComplete Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PrintReceiptComplete();
                }
                return _instance;
            }
        }
        public PrintReceiptComplete()
        {
            InitializeComponent();
        }
        public DataGridView getDataGridView()
        {
            return dataGridView1;
        }
        public void setlbBalance(string balance)
        {
            lbBalance.Text = balance + " VND";
        }

        
        public void settingDataGridView()
        {
            if (dataGridView1 != null)
            {
                //dataGridView1.ColumnCount = 2;
                //dataGridView1.Columns["LogDate"].HeaderText = "Ngày giao dịch";
                //dataGridView1.Columns["Amount"].HeaderText = "Số tiền giao dịch";
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = (dataGridView1.ClientRectangle.Height - dataGridView1.ColumnHeadersHeight) / dataGridView1.Rows.Count;
                }
            }
        }
    }
}
