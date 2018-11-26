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
    public partial class CheckBalance : UserControl
    {
        private static CheckBalance _instance;
        public static CheckBalance Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CheckBalance();
                }
                return _instance;        
            }
        }

        public CheckBalance()
        {
            InitializeComponent();
        }
        public Label getlbBalance()
        {
            return lbBalance;
        }
        public void setlbBalance(string balance)
        {
            lbBalance.Text = balance + " VND";
        }

        private void CheckBalance_Load(object sender, EventArgs e)
        {

        }
    }
}
