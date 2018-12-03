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
    public partial class GetBackCard : UserControl
    {
        private static GetBackCard _instance;
        public static GetBackCard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GetBackCard();
                }
                return _instance;
            }
        }

        public GetBackCard()
        {
            InitializeComponent();
        }
    }
}
