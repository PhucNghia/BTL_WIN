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
    public partial class ValidatePin : UserControl
    {
        private static ValidatePin _instance;
        public static ValidatePin Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ValidatePin();
                }
                return _instance;
            }
        }

        public ValidatePin()
        {
            InitializeComponent();
        }

        public string getTextBoxPin()
        {
            return txtPin.Text;
        }

        public void setTextBoxPin(string number)
        {
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

        public Label getlblBlockCard()
        {
            return lblBlockCard;
        }
    }
}
