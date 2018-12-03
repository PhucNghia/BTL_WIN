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
    public partial class CardBlockPinFail : UserControl
    {
        private static CardBlockPinFail _instance;
        public static CardBlockPinFail Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CardBlockPinFail();
                }
                return _instance;
            }
        }
        public CardBlockPinFail()
        {
            InitializeComponent();
        }
    }
}
