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
    public partial class CheckChangePIN : UserControl
    {
        private static CheckChangePIN _instance;
        public static CheckChangePIN Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CheckChangePIN();
                }
                return _instance;
            }
        }
        public CheckChangePIN()
        {
            InitializeComponent();
        }

        public string getTextBoxPin()
        {
            return txtPin.Text;
        }

        public void setTextBoxPin(string number)
        {
            int limitPin;
            limitPin = getTextBoxPin().Length;
            if (limitPin < 6)
                txtPin.Text += number;
        }

        public void clearTextBoxPin()
        {
            txtPin.Text = "";
        }

        public Label getlblCheckPin()
        {
            return lblCheckPIN;
        }

        
    }
}
