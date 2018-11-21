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
        public static string state;
        ValidateCard validateCard = new ValidateCard();
        public FormMain()
        {
            InitializeComponent();

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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                checkCardNo();
            }
        }

        private void btnRight3_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                checkCardNo();
            }
        }

        // Function check CardNo
        private void checkCardNo()
        {
            bool checkSuccess = cardBUL.checkCardNo(ValidateCard.Instance.getTextBoxCardNo());
            if (checkSuccess)
            {
                bool checkExpiredDate = cardBUL.getExpiredDate(ValidateCard.Instance.getTextBoxCardNo());
                if (checkExpiredDate)
                {
                    if (!panelMain.Controls.Contains(ValidatePin.Instance))
                    {
                        panelMain.Controls.Add(ValidatePin.Instance);
                        ValidatePin.Instance.Dock = DockStyle.Fill;
                        ValidatePin.Instance.BringToFront();
                    }
                    else
                    {
                        ValidatePin.Instance.BringToFront();
                    }
                    state = "ValidatePin";
                }
                else
                {
                    ValidateCard.Instance.getlblExpiredDate().Visible = true;
                    ValidateCard.Instance.getlblCheckMa().Visible = false;
                }
            }
            else
            {
                ValidateCard.Instance.getlblCheckMa().Visible = true;
                ValidateCard.Instance.getlblExpiredDate().Visible = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ValidateCard.Instance.clearTextBoxCardNo();
        }

        private void enterTextBox(string number)
        {
            if (state.Equals("ValidateCard"))
            {
                ValidateCard.Instance.setTextBoxCardNo(number);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("1");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("2");
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("3");
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("4");
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("5");
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("6");
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("7");
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("8");
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("9");
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (state.Equals("ValidateCard"))
            {
                enterTextBox("0");
            }
        }
    }
}
