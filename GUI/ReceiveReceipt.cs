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
    public partial class ReceiveReceipt : UserControl
    {
        private static ReceiveReceipt _instance;
        public static ReceiveReceipt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiveReceipt();
                }
                return _instance;
            }
        }
        public ReceiveReceipt()
        {
            InitializeComponent();
        }
    }
}
