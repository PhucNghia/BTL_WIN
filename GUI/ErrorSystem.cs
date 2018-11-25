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
    public partial class ErrorSystem : UserControl
    {
        private static ErrorSystem _instance;
        public static ErrorSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ErrorSystem();
                }
                return _instance;
            }
        }

        public ErrorSystem()
        {
            InitializeComponent();
        }

        public void showLbl()
        {
            label1.Visible = true;
        }
    }
}
