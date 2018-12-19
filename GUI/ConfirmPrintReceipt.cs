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
    public partial class ConfirmPrintReceipt : UserControl
    {
        private static ConfirmPrintReceipt _instance;
        public static ConfirmPrintReceipt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfirmPrintReceipt();
                }
                return _instance;
            }
        }
        public ConfirmPrintReceipt()
        {
            InitializeComponent();
        }
    }
}
