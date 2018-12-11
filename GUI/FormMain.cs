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
using DTOs;
using BULs;

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
        CustomerBUL customerBUL = new CustomerBUL();
        MoneyBUL monney = new MoneyBUL();

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
            if (state.Equals("ChangePIN") || state.Equals("CheckChangePIN") || state.Equals("ChangePINSuccess")
                || state.Equals("CheckPINFail") || state.Equals("CustomWithDraw"))
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
            else if (state.Equals("Withdraw") || state.Equals("CustomWithdraw") ||
                state.Equals("CashTransferCard") || state.Equals("CashTransferEnterMoney"))
            {
                addUserControl(ListService.Instance);
                state = "ListService";
            }
            else if (state.Equals("CashTransMoneyferFail1") || state.Equals("CashTransMoneyferFail2") ||
                state.Equals("DisagreeTransaction") || state.Equals("AgreeBill"))
            {
                CashTransfer.Instance.clearTextBoxCardNo();
                CashTransfer.Instance.clearTextBoxCardNoName();
                CashTransfer.Instance.clearTextBoxCardNoTo();
                CashTransfer.Instance.clearTextBoxCardNoToName();
                CashTransfer.Instance.clearTextBoxMoney();
                addUserControl(ListService.Instance);
                state = "ListService";
            }
        }

        private async void btnEnter_Click(object sender, EventArgs e)
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
                createLog("LT004", "ATM001", getTextBoxCardNo(), 0, "Success", "");
                state = "OtherTransaction";
                addUserControl(OtherTransaction.Instance);
            }
            else if (state.Equals("CustomWithdraw"))
            {
                int money = CustomWithDraw.Instance.getTextBoxCustomWithDraw();
                withdraw(money);
            }
            else if (state.Equals("CashTransferCard"))
            {
                transfer();
            }
            else if (state.Equals("CashTransferEnterMoney"))
            {
                checkMoneyTransfer();
            }
            else if (state.Equals("CashTransferMoneySuccess"))
            {
                Success.Instance.setLabelBalance(accountBUL.updateBalance(
                    Convert.ToInt32(CashTransfer.Instance.getTextBoxMoney()),
                    CashTransfer.Instance.getTextBoxCardNo(),
                    CashTransfer.Instance.getTextBoxCardNoTo(),
                    3300) + "");
                createLog("LT002", "ATM001", CashTransfer.Instance.getTextBoxCardNo(),
                    Convert.ToInt32(CashTransfer.Instance.getTextBoxMoney()), "Chuyển khoản thành công", CashTransfer.Instance.getTextBoxCardNoTo());
                addUserControl(Success.Instance);
                state = "AgreeBill";
            }
            else if (state.Equals("AgreeBill"))
            {
                addUserControl(Bill.Instance);
                exportReceipt.exportReceiptCashTransfer(
                 CashTransfer.Instance.getTextBoxCardNo(),
                 CashTransfer.Instance.getTextBoxCardNoName(),
                 CashTransfer.Instance.getTextBoxCardNoTo(),
                 CashTransfer.Instance.getTextBoxCardNoToName(),
                 Convert.ToInt32(CashTransfer.Instance.getTextBoxMoney())
                 );
                await Task.Delay(3000);
                addUserControl(OtherTransaction.Instance);

                state = "AgreeTransaction";
            }
            else if (state.Equals("AgreeTransaction"))
            {
                CashTransfer.Instance.clearTextBoxCardNo();
                CashTransfer.Instance.clearTextBoxCardNoName();
                CashTransfer.Instance.clearTextBoxCardNoTo();
                CashTransfer.Instance.clearTextBoxCardNoToName();
                CashTransfer.Instance.clearTextBoxMoney();
                addUserControl(ListService.Instance);
                state = "ListService";
            }
            else if (state.Equals("CashTransMoneyferFail1"))
            {
                Fail.Instance.clearLabel1();
                Fail.Instance.clearLabel2();
                Fail.Instance.clearLabel3();
                Fail.Instance.setLabel1("Xin lỗi, giao dịch không thành công");
                Fail.Instance.setLabel2("Xin vui lòng kiểm tra lại");
                Fail.Instance.setLabel3("(Không được phép chuyển tiền vào tài khoản USD)");

                Fail.Instance.ShowErrorChangLog();
                addUserControl(Fail.Instance);
                state = "DisagreeBill1";
            }
            else if (state.Equals("CashTransMoneyferFail2"))
            {
                Fail.Instance.clearLabel1();
                Fail.Instance.clearLabel2();
                Fail.Instance.clearLabel3();

                Fail.Instance.setLabel1("Số tiền trong TK không đủ cho giao dịch rút tiền\n");
                Fail.Instance.setLabel2("\t\tSố dư hiện có trong tài khoản :\n" +
                   accountBUL.getBalanceInt(CashTransfer.Instance.getTextBoxCardNo()));

                Fail.Instance.ShowErrorChangLog();
                addUserControl(Fail.Instance);
                state = "DisagreeBill2";
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
            else if (state.Equals("PrintReceipt"))
            {
                //PrintReceiptComplete.Instance.CardNo = getTextBoxCardNo();
                addUserControl(PrintReceiptComplete.Instance);
                state = "PrintReceiptComplete";

                string balance = accountBUL.getBalance(getTextBoxCardNo());
                PrintReceiptComplete.Instance.setlbBalance(balance);
                PrintReceiptComplete.Instance.LoadLog(getTextBoxCardNo());
            }
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            if (state.Equals("Withdraw"))
            {
                withdraw(1000000);
            }
            else if (state.Equals("ListService"))
            {
                addUserControl(CheckBalance.Instance);
                state = "CheckBalance";
                string balance = accountBUL.getBalance(getTextBoxCardNo());
                CheckBalance.Instance.setlbBalance(balance);
                createLog("LT003", "ATM001", getTextBoxCardNo(), 0, "Vắn tin thành công", "");
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
            else if (state.Equals("ListService"))
            {
                addUserControl(CashTransfer.Instance);
                CashTransfer.Instance.HideLabel();
                state = "CashTransferCard";

                CashTransfer.Instance.clearTextBoxCardNo();
                CashTransfer.Instance.clearTextBoxCardNoName();
                CashTransfer.Instance.clearTextBoxCardNoTo();
                CashTransfer.Instance.clearTextBoxCardNoToName();
                CashTransfer.Instance.clearTextBoxMoney();
            }
        }

        private async void btnRight3_Click(object sender, EventArgs e)
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
            else if (state.Equals("CheckBalance"))
            {
                Task delay = Task.Delay(3000);
                addUserControl(ConfirmPrintReceipt.Instance);
                delay.Wait();

                addUserControl(OtherDeal.Instance);
                state = "OtherDeal";
                exportReceipt.exportBalance(getTextBoxCardNo(), "CheckBalance");
            }
            else if (state.Equals("OtherDeal"))
            {
                addUserControl(ListService.Instance);
                state = "ListService";
            }
            else if (state.Equals("PrintReceiptComplete"))
            {
                PrintReceiptComplete.Instance.ClearPanel();
                Task delay = Task.Delay(3000);
                addUserControl(ReceiveReceipt.Instance);
                delay.Wait();

                addUserControl(OtherDeal.Instance);
                state = "OtherDeal";
                exportReceipt.exportReceipt1(getTextBoxCardNo(), "PrintReceiptCompelete");
            }
            else if (state.Equals("CashTransferCard"))
            {
                transfer();
            }
            else if (state.Equals("CashTransferEnterMoney"))
            {
                if (checkMoneyTransfer())
                {
                    Success.Instance.setLabelBalance(accountBUL.updateBalance(
                    Convert.ToInt32(CashTransfer.Instance.getTextBoxMoney()),
                    CashTransfer.Instance.getTextBoxCardNo(),
                    CashTransfer.Instance.getTextBoxCardNoTo(),
                    3300) + "");
                    createLog("LT002", "ATM001", CashTransfer.Instance.getTextBoxCardNo(),
                        Convert.ToInt32(CashTransfer.Instance.getTextBoxMoney()), "Chuyển khoản thành công", CashTransfer.Instance.getTextBoxCardNoTo());
                    addUserControl(Success.Instance);
                    state = "AgreeBill";
                }
                if (state.Equals("CashTransMoneyferFail2"))
                {
                    Fail.Instance.clearLabel1();
                    Fail.Instance.clearLabel2();
                    Fail.Instance.clearLabel3();

                    Fail.Instance.setLabel1("Số tiền trong TK không đủ cho giao dịch rút tiền\n");
                    Fail.Instance.setLabel2("\tSố dư hiện có trong tài khoản :\n" +
                        accountBUL.getBalanceInt(CashTransfer.Instance.getTextBoxCardNo()));

                    Fail.Instance.ShowErrorChangLog();
                    addUserControl(Fail.Instance);
                    state = "DisagreeBill2";
                }
            }
            else if (state.Equals("AgreeBill"))
            {
                addUserControl(Bill.Instance);
                exportReceipt.exportReceiptCashTransfer(
                    CashTransfer.Instance.getTextBoxCardNo(),
                    CashTransfer.Instance.getTextBoxCardNoName().Trim(),
                    CashTransfer.Instance.getTextBoxCardNoTo(),
                    CashTransfer.Instance.getTextBoxCardNoToName().Trim(),
                    Convert.ToInt32(CashTransfer.Instance.getTextBoxMoney()));
                await Task.Delay(3000);
                addUserControl(OtherTransaction.Instance);

                state = "AgreeTransaction";
            }

            else if (state.Equals("AgreeTransaction"))
            {
                CashTransfer.Instance.clearTextBoxCardNo();
                CashTransfer.Instance.clearTextBoxCardNoName();
                CashTransfer.Instance.clearTextBoxCardNoTo();
                CashTransfer.Instance.clearTextBoxCardNoToName();
                CashTransfer.Instance.clearTextBoxMoney();
                addUserControl(ListService.Instance);
                state = "ListService";
            }
            else if (state.Equals("CashTransMoneyferFail1"))
            {
                Fail.Instance.clearLabel1();
                Fail.Instance.clearLabel2();
                Fail.Instance.clearLabel3();
                Fail.Instance.setLabel1("Xin lỗi, giao dịch không thành công");
                Fail.Instance.setLabel2("Xin vui lòng kiểm tra lại");
                Fail.Instance.setLabel3("(Không được phép chuyển tiền vào tài khoản USD)");

                Fail.Instance.ShowErrorChangLog();
                addUserControl(Fail.Instance);
                state = "DisagreeBill1";
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
            else if (state.Equals("DisagreeBill1") || state.Equals("DisagreeBill2")
                || state.Equals("CashTransferEnterMoney") || state.Equals("CashTransferCard"))
            {
                CashTransfer.Instance.clearTextBoxCardNo();
                CashTransfer.Instance.clearTextBoxCardNoName();
                CashTransfer.Instance.clearTextBoxCardNoTo();
                CashTransfer.Instance.clearTextBoxCardNoToName();
                CashTransfer.Instance.clearTextBoxMoney();
                addUserControl(ListService.Instance);
                state = "ListService";
            }
            else if (state.Equals("AgreeBill"))
            {
                state = "ListService";
                addUserControl(ListService.Instance);
            }
            else if (state.Equals("AgreeTransaction"))
            {
                state = "ListService";
                addUserControl(ListService.Instance);
            }
            else if (state.Equals("CheckBalance"))
            {
                addUserControl(ListService.Instance);
                state = "ListService";
            }
            else if (state.Equals("OtherDeal"))
            {
                addUserControl(ValidateCard.Instance);
                state = "ValidateCard";
                clearTextBoxCardNo();
            }
            else if (state.Equals("PrintReceiptComplete"))
            {
                PrintReceiptComplete.Instance.ClearPanel();
                addUserControl(ListService.Instance);
                state = "ListService";
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
            {
                ValidatePin.Instance.setTextBoxPin(number);
            }
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
            string cardNo = getTextBoxCardNo();
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
            string cardNo = getTextBoxCardNo();
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
            else if (changePin && confirmPin.Length == 6 && pin != confirmPin)
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

        // Function Transfer
        private void transfer()
        {
            bool checkCardNo = cardBUL.checkCurrentCardNo(CashTransfer.Instance.getTextBoxCardNo(), getTextBoxCardNo());
            bool checkCardNoTo = cardBUL.checkCardNo(CashTransfer.Instance.getTextBoxCardNoTo());

            if (!checkCardNo || !checkCardNoTo)
            {
                CashTransfer.Instance.setTextBoxCardNoToName("Tên tài khoản không hợp lệ");
                CashTransfer.Instance.setTextBoxCardNoName("Tên tài khoản không hợp lệ");
                //string nameCardNo = customerBUL.getNameCustomer(CashTransfer.Instance.getTextBoxCardNo().Trim());
                string nameCardNoTo = customerBUL.getNameCustomer(CashTransfer.Instance.getTextBoxCardNoTo().Trim());
                //CashTransfer.Instance.setTextBoxCardNoName(nameCardNo);
                CashTransfer.Instance.setTextBoxCardNoToName(nameCardNoTo);
                CashTransfer.Instance.ShowLabel();

                if (CashTransfer.Instance.getTextBoxCardNo() != null
                && CashTransfer.Instance.getTextBoxCardNoTo() != null
                && CashTransfer.Instance.getTextBoxCardNoToName() != null)
                {
                    CashTransfer.Instance.ShowImage();
                    string textboxMoney = CashTransfer.Instance.getTextBoxMoney();
                    //bool checkTextBoxMoney = cardBUL.checkCardNo(CashTransfer.Instance.getTextBoxMoney());
                    if (textboxMoney != null)
                    {
                        state = "CashTransMoneyferFail1";
                    }
                }
            }
            else
            {
                if (CashTransfer.Instance.getTextBoxCardNo() != null
                && CashTransfer.Instance.getTextBoxCardNoName() != null
                && CashTransfer.Instance.getTextBoxCardNoName() != null
                && CashTransfer.Instance.getTextBoxCardNoTo() != null)
                {
                    string nameCardNo = customerBUL.getNameCustomer(CashTransfer.Instance.getTextBoxCardNo().Trim());
                    string nameCardNoTo = customerBUL.getNameCustomer(CashTransfer.Instance.getTextBoxCardNoTo().Trim());
                    CashTransfer.Instance.setTextBoxCardNoName(nameCardNo);
                    CashTransfer.Instance.setTextBoxCardNoToName(nameCardNoTo);
                    CashTransfer.Instance.ShowLabel();
                    CashTransfer.Instance.ShowImage();
                    state = "CashTransferEnterMoney";
                }
            }
        }

        // Function check money transfer
        private bool checkMoneyTransfer()
        {
            if (CashTransfer.Instance.getTextBoxMoney() != null
                && CashTransfer.Instance.getTextBoxCardNoToName() != null)
            {
                try
                {
                    string tbMoney = CashTransfer.Instance.getTextBoxMoney();
                    int money = Convert.ToInt32(tbMoney);
                    string cardNo = CashTransfer.Instance.getTextBoxCardNo();
                    bool checkMoney = accountBUL.compareBalance(money, cardNo);

                    if (!checkMoney)
                    {
                        state = "CashTransMoneyferFail2";
                        return false;
                    }
                    else
                    {
                        state = "CashTransferMoneySuccess";
                        return true;
                    }
                }
                catch
                {
                    state = "CashTransMoneyferFail2";
                    return false;
                }
            }
            else
                state = "CashTransMoneyferFai2";
            return false;
        }
    }
}