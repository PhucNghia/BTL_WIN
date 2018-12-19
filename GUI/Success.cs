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
    public partial class Success : UserControl
    {
        private static Success _instance;
        MoneyBUL moneyBUL = new MoneyBUL();

        public void setLabelBalance(string str)
        {
            lbBalance.Text = moneyBUL.formatMoney(int.Parse(str));
        }

        public Success()
        {
            InitializeComponent();
        }

        public static Success Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Success();
                }
                return _instance;
            }
        }
    }
}
