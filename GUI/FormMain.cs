using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULs;

namespace GUI
{
    public partial class FormMain : Form
    {
        CardBUL cardBUL = new CardBUL();
        AccountBUL accountBUL = new AccountBUL();
        public static string state;
        public FormMain()
        {
            InitializeComponent();
            state = "ValidateCard";
            addUserControl(ValidateCard.Instance);
        }

        // ============= Process Button =============
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                ValidateCard.Instance.clearTextBoxCardNo();
            }
            else if (state.Equals("ValidatePin"))
            {
                ValidatePin.Instance.clearTextBoxPin();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                checkCardNo();
            }
            else if (state.Equals("ValidatePin"))
            {
                checkPIN();
            }
        }

        private void btnLeft1_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            if (state.Equals("ListService"))
            {
                addUserControl(CheckBalance.Instance);
                state = "CheckBalance";
            }
        }

        private void btnLeft3_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft4_Click(object sender, EventArgs e)
        {

        }

        private void btnRight1_Click(object sender, EventArgs e)
        {

        }

        private void btnRight2_Click(object sender, EventArgs e)
        {

        }

        private void btnRight3_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                checkCardNo();
            }
            else if (state.Equals("ValidatePin"))
            {
                checkPIN();
            }
        }

        private void btnRight4_Click(object sender, EventArgs e)
        {

        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            enterTextBox("1");
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            enterTextBox("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            enterTextBox("3");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            enterTextBox("4");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            enterTextBox("5");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            enterTextBox("6");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            enterTextBox("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            enterTextBox("8");
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            enterTextBox("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            enterTextBox("0");
        }

        // Function Add User Control to FormMain
        private void addUserControl(UserControl userControl)
        {
            if (!panelMain.Controls.Contains(userControl))
            {
                panelMain.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
                userControl.BringToFront();
            }
            else
            {
                userControl.BringToFront();
            }
        }

        // Function enter Number to Texbox
        private void enterTextBox(string number)
        {
            if (state.Equals("ValidateCard"))
            {
                ValidateCard.Instance.setTextBoxCardNo(number);
            }
            else if (state.Equals("ValidatePin"))
            {
                ValidatePin.Instance.setTextBoxPin(number);
            }
        }

        // Function check CardNo
        private void checkCardNo()
        {
            string cardNo = ValidateCard.Instance.getTextBoxCardNo();
            bool checkSuccess = cardBUL.checkCardNo(cardNo);
            if (checkSuccess)
            {
                bool checkExpiredDate = cardBUL.getExpiredDate(cardNo);
                if (checkExpiredDate)
                {
                    state = "ValidatePin";
                    addUserControl(ValidatePin.Instance);
                }
                else
                {
                    ValidateCard.Instance.getlblExpiredDate().Visible = true;
                    ValidateCard.Instance.getlblChecCardNo().Visible = false;
                }
            }
            else
            {
                ValidateCard.Instance.getlblChecCardNo().Visible = true;
                ValidateCard.Instance.getlblExpiredDate().Visible = false;
            }
        }

        // Function check Pin
        private void checkPIN()
        {
            string cardNo = ValidateCard.Instance.getTextBoxCardNo();
            string pin = ValidatePin.Instance.getTextBoxPin();

            bool checkPin = cardBUL.getPIN(cardNo, pin);
            bool checkStatus = cardBUL.getStatus(cardNo);
            if(checkPin && checkStatus)
            {
                state = "ListService";
                addUserControl(ListService.Instance);
            }
            else if(checkPin && !checkStatus)
            {
                ValidatePin.Instance.getlblBlockCard().Visible = true;
                ValidatePin.Instance.getlblCheckPin().Visible = false;
            }
            else if(!checkPin && checkStatus)
            {
                cardBUL.updateAttemptStatus(cardNo);
                ValidatePin.Instance.getlblCheckPin().Visible = true;
                ValidatePin.Instance.getlblBlockCard().Visible = false;
            }
            else
            {
                ValidatePin.Instance.getlblCheckPin().Visible = true;
                ValidatePin.Instance.getlblBlockCard().Visible = true;
            }
        }
    }
}
