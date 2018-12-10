using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using BULs;
using DALs;
using DTO;

namespace GUI
{
    public partial class PrintReceiptComplete : UserControl
    {
        private static PrintReceiptComplete _instance;
        LogBUL logBUL = new LogBUL();
        MoneyBUL moneyBUL = new MoneyBUL();
        //private string cardNo;
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

        //public string CardNo { get => cardNo; set => cardNo = value; }

        public PrintReceiptComplete()
        {
            InitializeComponent();  
        }
        public void setlbBalance(string balance)
        {
            lbBalance1.Text = balance + " VND";
        }
        
        public void LoadLog(string cardNo)
        {
            List<LogDTO> logList = logBUL.LoadLogList(cardNo);
            foreach (LogDTO item in logList)
            {   
                
                Label lbl1 = new Label();
                lbl1.Size = new System.Drawing.Size(100, 20);
                lbl1.Text = item.LogDate.ToString("dd/MM/yyyy") ;
                pannel.Controls.Add(lbl1);

                Label lbl4 = new Label();
                lbl4.Size = new System.Drawing.Size(100, 20);
                lbl4.Text = item.LogDate.ToString("hh:mm");
                pannel.Controls.Add(lbl4);

                Label lbl2 = new Label();
                lbl2.Size = new System.Drawing.Size(100, 20);
                lbl2.Text = item.LogTypeID;
                pannel.Controls.Add(lbl2);

                Label lbl3 = new Label();
                lbl3.Size = new System.Drawing.Size(100, 20);
                lbl3.Text = moneyBUL.formatMoney(int.Parse(item.Amount.ToString()));
                pannel.Controls.Add(lbl3);

            }
        }
        public void ClearPanel()
        {
            pannel.Controls.Clear();
        }

    }
}
