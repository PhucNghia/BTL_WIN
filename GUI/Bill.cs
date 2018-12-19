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
    public partial class Bill : UserControl
    {
        private static Bill _instance;

        public Bill()
        {
            InitializeComponent();
        }

        public static Bill Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Bill();
                }
                return _instance;
            }
        }
    }
}
