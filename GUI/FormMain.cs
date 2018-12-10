using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using BULs;
using System.Diagnostics;

namespace GUI
{
    public partial class FormMain : Form
    {
        CardBUL cardBUL = new CardBUL();
        LogBUL logBUL = new LogBUL();
        StockBUL stockBUL = new StockBUL();
        AccountBUL accountBUL = new AccountBUL();
        ConfigBUL configBUL = new ConfigBUL();
        WithdrawLimitBUL withdrawLimitBUL = new WithdrawLimitBUL();
        ExportReceipt exportReceipt = new ExportReceipt();
        private string cardNo = null;
        public static string state;
        public static int moneyForReceipt = 0;

        public string getTextBoxCardNo()
        {
            //return txtCardNo.Text;
            return cardNo;
        }

        public void setTextBoxCardNo(string number)
        {
            txtCardNo.Text += number;
        }

        public void clearTextBoxCardNo()
        {
            txtCardNo.Text = "";
        }

        public FormMain()
        {
            InitializeComponent();
            state = "ValidateCard";
            addUserControl(ValidateCard.Instance);
            txtCardNo.Focus();
            
        }

        // ============= Process Button =============
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                // ValidateCard.Instance.clearTextBoxCardNo();
                clearTextBoxCardNo();
            }
            else if (state.Equals("ValidatePin"))
            {
                ValidatePin.Instance.clearTextBoxPin();
            }
            else if (state.Equals("CheckChangePIN"))
            {
                CheckChangePIN.Instance.clearTextBoxPin();
            }
            else if (state.Equals("ChangePIN"))
            {
                ChangePIN.Instance.clearNewPIN();
            }
            else if (state.Equals("ConfirmChangePIN"))
            {
                ConfirmChangePIN.Instance.clearNewPIN();
            }
            else if (state.Equals("CustomWithdraw"))
            {
                CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // back to List service 
            if (state.Equals("ChangePIN") || state.Equals("CheckChangePIN") || state.Equals("ChangePINSuccess") || state.Equals("CheckPINFail")
                || state.Equals("CustomWithDraw"))
            {
                ChangePIN.Instance.clearNewPIN();
                ChangePIN.Instance.reset();
                CheckChangePIN.Instance.clearTextBoxPin();
                addUserControl(ListService.Instance);
                state = "ListService";
                ListService.Instance.BringToFront();
            }
            else if (state.Equals("ListService"))
            {
                addUserControl(ValidateCard.Instance);
                state = "ValidateCard";
            }
            else if (state.Equals("Withdraw") || state.Equals("CustomWithdraw"))
            {
                addUserControl(ListService.Instance);
                state = "ListService";
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                cardNo = txtCardNo.Text;
                checkCardNo();
            }
            else if (state.Equals("ValidatePin"))
            {
                checkPIN();
            }
            else if (state.Equals("CheckChangePIN"))
            {
                checkChangePIN();
            }
            else if (state.Equals("ChangePIN"))
            {
                confirmChangePIN();
            }
            else if (state.Equals("ConfirmChangePIN"))
            {
                changePIN();
            }
            else if (state.Equals("ChangePINSuccess"))
            {
                state = "OtherTransaction";
                addUserControl(OtherTransaction.Instance);
            }
            else if (state.Equals("CustomWithdraw"))
            {
                int money = CustomWithDraw.Instance.getTextBoxCustomWithDraw();
                withdraw(money);
                state = "CustomWithdraw";
            }
        }

        #region btnLeft
        private void btnLeft1_Click(object sender, EventArgs e)
        {
            if (state.Equals("ListService"))
            {
                addUserControl(Withdraw.Instance);
                state = "Withdraw";
            }
            else if (state.Equals("Withdraw"))
            {
                withdraw(100000);
            }
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            if (state.Equals("Withdraw"))
            {
                withdraw(1000000);
            }
        }

        private void btnLeft3_Click(object sender, EventArgs e)
        {
            if (state.Equals("ListService"))
            {
                state = "CheckChangePIN";
                addUserControl(CheckChangePIN.Instance);
            }
            else if (state.Equals("Withdraw"))
            {
                withdraw(2000000);
            }
        }

        private void btnLeft4_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region btnRight
        private void btnRight1_Click(object sender, EventArgs e)
        {
            if (state.Equals("Withdraw"))
            {
                withdraw(500000);
            }
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            if (state.Equals("Withdraw"))
            {
                withdraw(1500000);
            }
        }

        private void btnRight3_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                cardNo = txtCardNo.Text;
                checkCardNo();
            }
            else if (state.Equals("ValidatePin"))
            {
                checkPIN();
            }
            else if (state.Equals("CheckChangePIN"))
            {
                checkChangePIN();
            }
            else if (state.Equals("OtherTransaction"))
            {
                state = "ListService";
                addUserControl(ListService.Instance);
            }
            else if (state.Equals("Withdraw"))
            {
                addUserControl(CustomWithDraw.Instance);
                state = "CustomWithdraw";
            }
            else if (state.Equals("SuccessWithdraw"))
            {
                Task delay = Task.Delay(3000);
                addUserControl(GetBackCard.Instance);
                delay.Wait();
                addUserControl(ValidateCard.Instance);
                state = "ValidateCard";

                // Export receipt
                exportReceipt.exportReceiptWithdraw(getTextBoxCardNo(), moneyForReceipt);

                clearTextBoxCardNo();
                ValidatePin.Instance.clearTextBoxPin();
            }
        }

        private void btnRight4_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("ValidateCard"))
            {
                clearTextBoxCardNo();
            }
            // state validate PIN
            else if (state.Equals("ValidatePin"))
            {
                ValidatePin.Instance.clearTextBoxPin();
                ValidatePin.Instance.getlblBlockCard().Visible = false;
                ValidatePin.Instance.getlblCheckPin().Visible = false;

                if (!panelMain.Controls.Contains(ValidateCard.Instance))
                {
                    panelMain.Controls.Add(ValidatePin.Instance);
                    ValidateCard.Instance.Dock = DockStyle.Fill;
                    ValidateCard.Instance.BringToFront();
                }
                else
                {
                    ValidateCard.Instance.BringToFront();
                }
                clearTextBoxCardNo();
                state = "ValidateCard";
            }
            else if (state.Equals("OtherTransaction"))
            {
                state = "ValidateCard";
                addUserControl(ValidateCard.Instance);
            }
            else if (state.Equals("SuccessWithdraw"))
            {
                Task delay = Task.Delay(3000);
                addUserControl(GetBackCard.Instance);
                delay.Wait();
                addUserControl(ValidateCard.Instance);
                state = "ValidateCard";
                clearTextBoxCardNo();
                ValidatePin.Instance.clearTextBoxPin();
            }
        }
        #endregion
        #region nhập số
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
        #endregion
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
                setTextBoxCardNo(number);
            }
            else if (state.Equals("ValidatePin"))
                ValidatePin.Instance.setTextBoxPin(number);
            else if (state.Equals("CheckChangePIN"))
            {
                CheckChangePIN.Instance.setTextBoxPin(number);
            }
            else if (state.Equals("ChangePIN"))
            {
                ChangePIN.Instance.setNewPIN(number);               
            }
            else if (state.Equals("ConfirmChangePIN"))
            {
                ConfirmChangePIN.Instance.setNewPIN(number);
            }
            else if (state.Equals("CustomWithdraw"))
                CustomWithDraw.Instance.setTextBoxCustomWithDrawn(number);
        }

        // Function check CardNo
        private void checkCardNo()
        {
            string cardNo =getTextBoxCardNo();
            bool checkSuccess = cardBUL.checkCardNo(cardNo);
            if (checkSuccess)
            {
                bool checkExpiredDate = cardBUL.getExpiredDate(cardNo);
                if (checkExpiredDate)
                {
                    state = "ValidatePin";
                    addUserControl(ValidatePin.Instance);
                    clearTextBoxCardNo();
                }
                else
                {
                    ValidateCard.Instance.getlblExpiredDate().Visible = true;
                    ValidateCard.Instance.getlblChecCardNo().Visible = false;
                    clearTextBoxCardNo();
                }
            }
            else
            {
                ValidateCard.Instance.getlblChecCardNo().Visible = true;
                ValidateCard.Instance.getlblExpiredDate().Visible = false;
                clearTextBoxCardNo();
            }
        }

        // Function check Pin
        private void checkPIN()
        {
            string cardNo =getTextBoxCardNo();
            string pin = ValidatePin.Instance.getTextBoxPin();

            bool checkPin = cardBUL.getPIN(cardNo, pin);
            bool checkStatus = cardBUL.getStatus(cardNo);
            if (checkPin && checkStatus)
            {
                state = "ListService";
                addUserControl(ListService.Instance);
                cardBUL.updateAttemptStatus(cardNo, true);
                ValidatePin.Instance.clearTextBoxPin();
            }
            else if (checkPin && !checkStatus)
            {
                state = "CardBlock";
                addUserControl(CardBlock.Instance);

                Thread.Sleep(3000);
                state = "ValidateCard";
                addUserControl(ValidateCard.Instance);
            }
            else if (!checkPin && checkStatus)
            {
                cardBUL.updateAttemptStatus(cardNo, false);
                state = "CheckPINFail";
                addUserControl(CheckPINFail.Instance);

                Thread.Sleep(3000);
                state = "ValidatePin";
                addUserControl(ValidatePin.Instance);

                ValidatePin.Instance.clearTextBoxPin();
            }
            else
            {
                state = "CardBlockPinFail";
                addUserControl(CardBlockPinFail.Instance);

                Thread.Sleep(3000);
                state = "ValidateCard";
                addUserControl(ValidateCard.Instance);
                ValidatePin.Instance.clearTextBoxPin();
            }
        }

        private void checkChangePIN()
        {
            string cardNo = getTextBoxCardNo();
            string pin = CheckChangePIN.Instance.getTextBoxPin();

            bool checkPin = cardBUL.getPIN(cardNo, pin);

            if (checkPin)
            {
                state = "ChangePIN";
                addUserControl(ChangePIN.Instance);
            }

            else if (!checkPin)
            {
                CheckChangePIN.Instance.getlblCheckPin().Visible = true;
                CheckChangePIN.Instance.clearTextBoxPin();

            }
        }

        private void confirmChangePIN()
        {
            string pin = ChangePIN.Instance.getNewPIN();
           
            if (pin.Length == 6)
            {
                state = "ConfirmChangePIN";
                addUserControl(ConfirmChangePIN.Instance);
                ConfirmChangePIN.Instance.clearNewPIN();
            }
            else
            {
                state = "ChangePIN";
                addUserControl(ChangePIN.Instance);
                ChangePIN.Instance.getcheckLB6so();
                ChangePIN.Instance.clearNewPIN();
            }

        }

        private void changePIN()
        {
            string cardNo = getTextBoxCardNo();
            string confirmPin = ConfirmChangePIN.Instance.getNewPIN();
            string pin = ChangePIN.Instance.getNewPIN();
            
            bool changePin = cardBUL.changePIN(cardNo, confirmPin);
            if (changePin && confirmPin.Length == 6 && pin == confirmPin)
            {
                state = "ChangePINSuccess";
                addUserControl(ChangePINSuccess.Instance);
                createLog("LT004", "ATM001", getTextBoxCardNo(), 0, "Đổi pin thành công", "");

                Thread.Sleep(3000);
                state = "OtherTransaction";
                addUserControl(OtherTransaction.Instance);
            }
            else if(changePin && confirmPin.Length == 6 && pin != confirmPin)
            {
                state = "ChangePIN";
                addUserControl(ChangePIN.Instance);
                ChangePIN.Instance.getPinFail();                   
                ChangePIN.Instance.clearNewPIN();
            }
            else if (changePin && confirmPin.Length != 6 && pin != confirmPin)
            {
                state = "ChangePIN";
                addUserControl(ChangePIN.Instance);
                ChangePIN.Instance.getPinFail();
                ChangePIN.Instance.clearNewPIN();
            }
            else
            {
                state = "ChangePIN";
                addUserControl(ChangePIN.Instance);
                ChangePIN.Instance.getcheckLB6so();
                ChangePIN.Instance.clearNewPIN();
            }                       
        }

        // function to create log
        private void createLog(string logType, string atmId, string cardNo, decimal amount, string details, string cardTo)
        {
            logBUL.createLog(logType, atmId, cardNo, amount, details, cardTo);
        }

        // Function Withdraw
        private void withdraw(int money)
        {  
            string cardNo = getTextBoxCardNo();
            bool checkMaxWithDraw = configBUL.getMaxWithDraw(money);        //trong bảng Config
            bool checkBalanceAndOD = accountBUL.checkBalanceAndOverDraft(cardNo, money);    // trong bảng OverDraft
            bool checkWithdrawLimit = withdrawLimitBUL.checkWithdrawLimit("LT001", "ATM001", cardNo, money); // trong bảng Withdraw Limit
            
            if (!checkMaxWithDraw)  // Vượt quá số tiền hệ thống / 1 lần rút
            {
                Task delay = Task.Delay(5000);
                addUserControl(OverMaximumWithDraw.Instance);
                delay.Wait();
                addUserControl(Withdraw.Instance);
                CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
            }
            else if (!checkBalanceAndOD)  // K đủ số dư và thấu chi
            {
                Task delay = Task.Delay(4000);
                addUserControl(OverMinimumBalance.Instance);
                OverMinimumBalance.Instance.setTextBoxBalance(accountBUL.getBalance(getTextBoxCardNo()));
                delay.Wait();
                addUserControl(Withdraw.Instance);
                CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
            }
            else if (!checkWithdrawLimit)   // Vượt quá số tiền rút trong ngày
            {
                Task delay = Task.Delay(4000);
                addUserControl(WithdrawLimit.Instance);
                delay.Wait();
                addUserControl(Withdraw.Instance);
                CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
            }
            else
            {
                string updateStock = stockBUL.updateQuantity(money);

                if (updateStock.Equals("ErrorMoneyType"))   // sai kiểu tiền và bội số
                {
                    Task delay = Task.Delay(3000);
                    addUserControl(ErrorMoneyType.Instance);
                    delay.Wait();
                    addUserControl(CustomWithDraw.Instance);
                    CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
                    state = "CustomWithdraw";
                    return;
                }
                else if (updateStock.Equals("ErrorSystem")) // Lỗi hệ thống (Hết tiền)
                {
                    Task delay = Task.Delay(4000);
                    addUserControl(ErrorSystem.Instance);
                    delay.Wait();
                    addUserControl(Withdraw.Instance);
                    CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
                }
                else    // Thành công
                {
                    bool updateBalance = accountBUL.updateBalance(money, cardNo);
                    if (updateBalance)
                    {
                        addUserControl(SuccessWithDraw.Instance);
                        SuccessWithDraw.Instance.setTextBoxBalance(accountBUL.getBalance(getTextBoxCardNo()));
                        state = "SuccessWithdraw";
                        createLog("LT001", "ATM001", cardNo, money, "Rút tiền hành công", "");
                        moneyForReceipt = money;
                        return;
                    }
                    CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
                }
            }
            state = "Withdraw";
        }
    }
}
