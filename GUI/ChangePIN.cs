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
    public partial class ChangePIN : UserControl
    {
        private static ChangePIN _instance;
        public static ChangePIN Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChangePIN();
                }
                return _instance;
            }
        }
        public ChangePIN()
        {
            InitializeComponent();
        }

        public void clearNewPIN()
        {
            txtPin.Text = "";
        }
        public string getNewPIN()
        {
            return txtPin.Text;
        }
        public void setNewPIN(string number)
        {   
            int limitPin;
            limitPin = getNewPIN().Length;
            if (limitPin <6)
                txtPin.Text += number;
        }

        public void showLbSuccess()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            txtPin.Visible = false;
        }

        public void showLbFail()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            txtPin.Visible = false;
        }

        public void reset()
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            txtPin.Visible = true;
        }
    }
}
