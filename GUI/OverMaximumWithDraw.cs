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
    public partial class OverMaximumWithDraw : UserControl
    {
        private static OverMaximumWithDraw _instance;
        public static OverMaximumWithDraw Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OverMaximumWithDraw();
                }
                return _instance;
            }
        }

        public OverMaximumWithDraw()
        {
            InitializeComponent();
        }
    }
}
