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
    public partial class CheckPINFail : UserControl
    {
        private static CheckPINFail _instance;
        public static CheckPINFail Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CheckPINFail();
                }
                return _instance;
            }
        }
        public CheckPINFail()
        {
            InitializeComponent();
        }
    }
}
