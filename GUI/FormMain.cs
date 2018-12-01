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
            else if (state.Equals("CheckChangePIN"))
            {
                CheckChangePIN.Instance.clearTextBoxPin();
            }
            else if (state.Equals("ChangePIN"))
            {
                ChangePIN.Instance.clearNewPIN();
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

                if (!panelMain.Controls.Contains(ListService.Instance))
                {
                    panelMain.Controls.Add(ListService.Instance);
                    ListService.Instance.Dock = DockStyle.Fill;
                    ListService.Instance.BringToFront();
                }
                else
                {
                    ListService.Instance.BringToFront();
                }
                state = "ListService";
                ListService.Instance.BringToFront();
            }
            else if (state.Equals("ListService"))
            {
                if (!panelMain.Controls.Contains(ValidateCard.Instance))
                {
                    panelMain.Controls.Add(ValidateCard.Instance);
                    ValidateCard.Instance.Dock = DockStyle.Fill;
                    ValidateCard.Instance.BringToFront();
                }
                else
                {
                    ValidateCard.Instance.BringToFront();
                }
                state = "ValidateCard";
            }
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
            else if (state.Equals("CheckChangePIN"))
            {
                checkChangePIN();
            }
            else if (state.Equals("ChangePIN"))
            {
                changePIN();
            }
            else if (state.Equals("ChangePINSuccess"))
            {
                createLog("LT004", "ATM001", ValidateCard.Instance.getTextBoxCardNo(), 0, "Success", "");
                state = "OtherTransaction";
                addUserControl(OtherTransaction.Instance);
            }
            else if (state.Equals("CustomWithDraw"))
            {
                int money = CustomWithDraw.Instance.getTextBoxCustomWithDraw();
                string cardNo = ValidateCard.Instance.getTextBoxCardNo();
                bool checkMaxWithDraw = configBUL.getMaxWithDraw(money);        //trong bảng Config
                bool checkWithDrawLimit = ;
                bool checkBalanceAndOD = accountBUL.checkBalanceAndOverDraft(cardNo, money);    // trong bảng OverDraft

                if (!checkMaxWithDraw)  // Vượt quá số tiền hệ thống / 1 lần rút 
                {
                    Task delay = Task.Delay(5000);
                    addUserControl(OverMaximumWithDraw.Instance);
                    delay.Wait();
                    addUserControl(CustomWithDraw.Instance);
                    CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
                }
                else if (!checkBalanceAndOD)  // K đủ số dư và thấu chi
                {
                    Task delay = Task.Delay(4000);
                    addUserControl(OverMinimumBalance.Instance);    
                    OverMinimumBalance.Instance.setTextBoxBalance(accountBUL.getBalance(ValidateCard.Instance.getTextBoxCardNo()));
                    delay.Wait();
                    addUserControl(CustomWithDraw.Instance);
                    CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
                }
                else
                {
                    string updateStock = stockBUL.updateQuantity(money);

                    if (updateStock.Equals("ErrorMoneyType"))   // sai kiểu tiền
                    {
                        Task delay = Task.Delay(4000);
                        addUserControl(ErrorMoneyType.Instance);
                        delay.Wait();
                        addUserControl(CustomWithDraw.Instance);
                        CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
                    }
                    else if (updateStock.Equals("ErrorSystem")) // Lỗi hệ thống (Hết tiền)
                    {
                        Task delay = Task.Delay(4000);
                        addUserControl(ErrorSystem.Instance);
                        delay.Wait();
                        addUserControl(ValidateCard.Instance);
                        CustomWithDraw.Instance.clearTextBoxCustomWithDraw();
                    }
                    else    // Thành công
                    {
                        bool updateBalance = accountBUL.updateBalance(money, cardNo);
                        if (updateBalance)
                        {
                            addUserControl(SuccessWithDraw.Instance);
                            SuccessWithDraw.Instance.setTextBoxBalance(accountBUL.getBalance(ValidateCard.Instance.getTextBoxCardNo()));
                            state = "SuccessWithDraw";
                        }
                    }
                }
            }
        }

        private void btnLeft1_Click(object sender, EventArgs e)
        {
            if (state.Equals("ListService"))
            {
                addUserControl(WithDraw.Instance);
                state = "WithDraw";
            }
            else if (state.Equals("WithDraw"))
            {
                MessageBox.Show("1lit");
            }
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            if (state.Equals("WithDraw"))
            {
                MessageBox.Show("1tr");
            }
        }

        private void btnLeft3_Click(object sender, EventArgs e)
        {
            if (state.Equals("ListService"))
            {
                state = "CheckChangePIN";
                addUserControl(CheckChangePIN.Instance);
            }
            else if (state.Equals("WithDraw"))
            {
                MessageBox.Show("2tr");
            }
        }

        private void btnLeft4_Click(object sender, EventArgs e)
        {

        }

        private void btnRight1_Click(object sender, EventArgs e)
        {
            if (state.Equals("WithDraw"))
            {
                MessageBox.Show("5lit");
            }
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            if (state.Equals("WithDraw"))
            {
                MessageBox.Show("1.5tr");
            }
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
            else if (state.Equals("CheckChangePIN"))
            {
                checkChangePIN();
            }
            else if (state.Equals("OtherTransaction"))
            {
                state = "ListService";
                addUserControl(ListService.Instance);
            }
            else if (state.Equals("WithDraw"))
            {
                addUserControl(CustomWithDraw.Instance);
                state = "CustomWithDraw";
            }
        }

        private void btnRight4_Click(object sender, EventArgs e)
        {
            // state validate card
            if (state.Equals("ValidateCard"))
            {
                ValidateCard.Instance.clearTextBoxCardNo();
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

                ValidateCard.Instance.clearTextBoxCardNo();
                state = "ValidateCard";
            }
            else if (state.Equals("OtherTransaction"))
            {
                state = "ValidateCard";
                addUserControl(ValidateCard.Instance);
            }
        }
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
                ValidateCard.Instance.setTextBoxCardNo(number);
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
            else if (state.Equals("CustomWithDraw"))
                CustomWithDraw.Instance.setTextBoxCustomWithDrawn(number);
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
                    ValidateCard.Instance.clearTextBoxCardNo();
                }
            }
            else
            {
                ValidateCard.Instance.getlblChecCardNo().Visible = true;
                ValidateCard.Instance.getlblExpiredDate().Visible = false;
                ValidateCard.Instance.clearTextBoxCardNo();
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
                cardBUL.updateAttemptStatus(cardNo, true);
            }
            else if (checkPin && !checkStatus)
            {
                state = "CardBlock";
                addUserControl(CardBlock.Instance);

                Thread.Sleep(3000);
                state = "ValidateCard";
                addUserControl(ValidateCard.Instance);
                //ValidatePin.Instance.getlblBlockCard().Visible = true;
                //ValidatePin.Instance.getlblCheckPin().Visible = false;
                //ValidatePin.Instance.clearTextBoxPin();
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
            string cardNo = ValidateCard.Instance.getTextBoxCardNo();
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
        private void changePIN()
        {
            string cardNo = ValidateCard.Instance.getTextBoxCardNo();
            string pin = ChangePIN.Instance.getNewPIN();

            bool changePin = cardBUL.changePIN(cardNo, pin);
            if (changePin)
            {
                state = "ChangePINSuccess";
                addUserControl(ChangePINSuccess.Instance);

                Thread.Sleep(3000);
                state = "OtherTransaction";
                addUserControl(OtherTransaction.Instance);

            }

        }
        // function to create log
        private void createLog(string logType, string atmId, string cardNo, decimal amount, string details, string cardTo)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            bool checkCreateLog = logBUL.createLog(logType, atmId, cardNo, date, amount, details, cardTo);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
