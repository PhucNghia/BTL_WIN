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
    public partial class OtherTransaction : UserControl
    {
        private static OtherTransaction _instance;
        public static OtherTransaction Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OtherTransaction();
                }
                return _instance;
            }
        }
        public OtherTransaction()
        {
            InitializeComponent();
        }
    }
}
