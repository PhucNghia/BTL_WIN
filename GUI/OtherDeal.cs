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
    public partial class OtherDeal : UserControl
    {
        private static OtherDeal _instance;
        public static OtherDeal Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OtherDeal();
                }
                return _instance;
            }
        }
        public OtherDeal()
        {
            InitializeComponent();
        }
    }
}
