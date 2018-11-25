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
    public partial class SuccessWithDraw : UserControl
    {
        private static SuccessWithDraw _instance;
        public static SuccessWithDraw Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SuccessWithDraw();
                }
                return _instance;
            }
        }

        public SuccessWithDraw()
        {
            InitializeComponent();
        }

        public void setTextBoxBalance(string money)
        {
            lblBalance.Text = money + " VND";
        }
    }
}
