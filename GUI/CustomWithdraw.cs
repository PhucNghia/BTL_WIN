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
    public partial class CustomWithDraw : UserControl
    {
        StockBUL stockBUL = new StockBUL();
        MoneyBUL moneyBUL = new MoneyBUL();

        private static CustomWithDraw _instance;
        public static CustomWithDraw Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomWithDraw();
                }
                return _instance;
            }
        }

        public CustomWithDraw()
        {
            InitializeComponent();
            if(stockBUL.getMultiples() >= 50000)
                lblMultiples.Text = moneyBUL.formatMoney(stockBUL.getMultiples()) + " Dong";
            else
                lblMultiples.Text = "50,000 Dong".ToString();
        }

        public int getTextBoxCustomWithDraw()
        {
            int number;
            Int32.TryParse(txtCustomWithDraw.Text, out number);
            return number;
        }

        public void setTextBoxCustomWithDrawn(string number)
        {
            txtCustomWithDraw.Text += number;
        }

        public void clearTextBoxCustomWithDraw()
        {
            txtCustomWithDraw.Text = "";
        }
    }
}
