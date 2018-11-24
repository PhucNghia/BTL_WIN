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
    public partial class Fail : UserControl
    {

        private static Fail _instance;

        public Fail()
        {
            InitializeComponent();
        }

        public static Fail Instance
        {
            get
            {
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        public void showErrorMoney()
        {
            lbErrorMoney.Visible = true;
            lbErrorCard.Visible = false;
        }

        public void showErrorCard()
        {
            lbErrorMoney.Visible = false;
            lbErrorCard.Visible = true;
        }
    }
}
