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
    public partial class ValidateCard : UserControl
    {
        private static ValidateCard _instance;
        public static ValidateCard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ValidateCard();
                }
                return _instance;
            }
        }

        public ValidateCard()
        {
            InitializeComponent();
        }

        public string getTextBoxCardNo()
        {
            return txtCardNo.Text;
        }

        public void setTextBoxCardNo(string number)
        {
            txtCardNo.Text += number;
        }

        public void clearTextBoxCardNo()
        {
            txtCardNo.Text = "";
        }

        public Label getlblChecCardNo()
        {
            return lblCheckCardNo;
        }

        public Label getlblExpiredDate()
        {
            return lblExpiredDate;
        }
    }
}
