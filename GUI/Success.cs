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
    public partial class Success : UserControl
    {

        private static Success _instance;

        public Success()
        {
            InitializeComponent();
        }

        public static Success Instance
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
    }
}
