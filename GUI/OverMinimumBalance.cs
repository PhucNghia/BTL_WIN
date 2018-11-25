using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class OverMinimumBalance : UserControl
    {
        private static OverMinimumBalance _instance;
        public static OverMinimumBalance Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OverMinimumBalance();
                }
                return _instance;
            }
        }

        public OverMinimumBalance()
        {
            InitializeComponent();
        }

        public void setTextBoxBalance(string money)
        {
            lblBalance.Text = money + " VND";
        }
    }
}
