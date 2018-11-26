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
using DTO;
using System.Threading;

namespace GUI
{
    public partial class FormMain : Form
    {
        CardBUL cardBUL = new CardBUL();
        AccountBUL accountBUL = new AccountBUL();
        private LogBUL logBUL = new LogBUL();
        private int pageNumber;
        private int numberRecord;
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
            if (state.Equals("PrintReceipt"))
            {
                addUserControl(PrintReceiptComplete.Instance);
                state = "PrintReceiptComplete";
                string balance = accountBUL.getBalance(ValidateCard.Instance.getTextBoxCardNo()).ToString();
                PrintReceiptComplete.Instance.setlbBalance(balance);
                pageNumber = 1;
                setDataGridView(pageNumber, numberRecord);
            }
            else if (state.Equals("PrintReceiptComplete"))
            {
                if (pageNumber - 1 < logBUL.getAllLog(ValidateCard.Instance.getTextBoxCardNo()).Count / numberRecord)
                {
                    pageNumber++;
                    setDataGridView(pageNumber, numberRecord);
                }
            }
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            if (state.Equals("ListService"))
            {
                addUserControl(CheckBalance.Instance);
                state = "CheckBalance";
                string balance = accountBUL.getBalance(ValidateCard.Instance.getTextBoxCardNo()).ToString();
                CheckBalance.Instance.setlbBalance(balance);
            }
        }

        private void btnLeft3_Click(object sender, EventArgs e)
        {

        }

        private void btnLeft4_Click(object sender, EventArgs e)
        {
            if (state.Equals("ListService"))
            {
                addUserControl(PrintReceipt.Instance);
                state = "PrintReceipt";             
            }
            else if (state.Equals("PrintReceipt"))
            {
                addUserControl(ListService.Instance);
                state = "ListService";
            }
            
        }
        // set data for DataGridView
        private void setDataGridView(int page, int record)
        {
            if (logBUL.getAllLog(ValidateCard.Instance.getTextBoxCardNo()) != null)
            {
                PrintReceiptComplete.Instance.getDataGridView().DataSource = logBUL.getAllLog(ValidateCard.Instance.getTextBoxCardNo()).Skip((page - 1) * record).Take(record).ToList();
            }
            PrintReceiptComplete.Instance.settingDataGridView();
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
            else if (state.Equals("CheckBalance"))
            {
                Thread.Sleep(3000);
                addUserControl(ConfirmPrintReceipt.Instance);
                state = "ConfirmPrintReceipt";
                
                addUserControl(OtherDeal.Instance);
                state = "OtherDeal";
            }
            else if (state.Equals("OtherDeal"))
            {
                addUserControl(ListService.Instance);
                state = "ListService";
            }
        }

        private void btnRight4_Click(object sender, EventArgs e)
        {
            if (state.Equals("CheckBalance"))
            {
                addUserControl(ValidateCard.Instance);
                state = "ValidateCard";
                ValidateCard.Instance.clearTextBoxCardNo();
            }
            else if (state.Equals("OtherDeal"))
            {
                addUserControl(ValidateCard.Instance);
                state = "ValidateCard";
                ValidateCard.Instance.clearTextBoxCardNo();
            }
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
            if (checkPin && checkStatus)
            {
                state = "ListService";
                addUserControl(ListService.Instance);
            }
            else if (checkPin && !checkStatus)
            {
                ValidatePin.Instance.getlblBlockCard().Visible = true;
                ValidatePin.Instance.getlblCheckPin().Visible = false;
            }
            else if (!checkPin && checkStatus)
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
