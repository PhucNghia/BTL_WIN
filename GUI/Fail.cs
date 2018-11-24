using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULs;

namespace GUI
{
    public partial class Fail : UserControl
    {
        MoneyBUL moneyBUL = new MoneyBUL();
        private static Fail _instance;

        public static Fail Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Fail();
                }
                return _instance;
            }

        }

        public Fail()
        {
            InitializeComponent();
        }

        public void clearLabel1()
        {
            label4.ResetText();
        }

        public void clearLabel2()
        {
            lbErrorCard.ResetText();
        }

        public void clearLabel3()
        {
            lbErrorMoney.ResetText();
        }

        public void setLabel1(string str)
        {
            //objectA.Location = new Point((int)A.position, objectA.Location.Y);
            this.label4.Location = new Point(this.Height / 2 + 10, 100);
            label4.Text = label4.Text + str;
        }

        public void setLabel2(string str)
        {
            this.lbErrorMoney.Location = new Point(this.Height / 2 + 30, 150);
            lbErrorMoney.Text = lbErrorMoney.Text + str;
        }

        public void setLabel3(string str)
        {
            this.lbErrorCard.Location = new Point(this.Height / 2 - 10, 200);
            lbErrorCard.Text = lbErrorCard.Text + str;
        }

        public void ShowErrorChangLog()
        {
            label4.Visible = true;
            lbErrorCard.Visible = true;
            lbErrorMoney.Visible = true;
        }

        public void showErrorMoney()
        {
            lbErrorMoney.Visible = true;
            lbErrorCard.Visible = false;
        }

        public void showErrorCard()
        {
            lbErrorMoney.Visible = false;
            lbErrorCard.Visible = true;
        }
    }
}
