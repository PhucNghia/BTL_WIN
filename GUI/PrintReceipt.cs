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
    public partial class PrintReceipt : UserControl
    {
        private static PrintReceipt _instance;
        public static PrintReceipt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PrintReceipt();
                }
                return _instance;
            }
        }
        public PrintReceipt()
        {
            InitializeComponent();
        }
    }
}
