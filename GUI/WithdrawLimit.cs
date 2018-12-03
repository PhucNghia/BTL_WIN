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
    public partial class WithdrawLimit : UserControl
    {
        private static WithdrawLimit _instance;
        public static WithdrawLimit Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WithdrawLimit();
                }
                return _instance;
            }
        }

        public WithdrawLimit()
        {
            InitializeComponent();
        }
    }
}
