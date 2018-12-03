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
    public partial class CardBlock : UserControl
    {
        private static CardBlock _instance;
        public static CardBlock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CardBlock();
                }
                return _instance;
            }
        }
        public CardBlock()
        {
            InitializeComponent();
        }
    }
}
