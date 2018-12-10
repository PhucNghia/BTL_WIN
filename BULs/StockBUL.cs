using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
    public class StockBUL
    {
        private StockDAL stockDAL = new StockDAL();

        public string updateQuantity(int money)
        {
            int multiples = getMultiples();
            
            if(multiples == 0)
                return "ErrorSystem";
            if (money % multiples != 0 || money < 50000)
                return "ErrorMoneyType";

            string totalMoney = customSheet(money);
            if (totalMoney.Equals("ErrorSystem") || multiples == 0)
                return "ErrorSystem";

            string[] arrMoney = totalMoney.Split('&');
            string[] typeOne = null;
            int count = 0;
            int moneyValue = 0;
            string moneyID = "";
            bool update = true;
            for (int i = 0; i < arrMoney.Length; i++)
            {
                typeOne = arrMoney[i].Split('-');
                count = Convert.ToInt32(typeOne[0]);
                moneyValue = Convert.ToInt32(typeOne[1]);
                moneyID = getMoneyId(moneyValue);
                update = stockDAL.updateQuantity("ATM001", moneyID, count);
                if (!update)
                    return "ErrorSystem";
            }
            return "Success";
        }

        public int getMultiples()
        {
            int[] money = new int[] { 500000, 200000, 100000, 50000, 20000, 10000 };
            for (int i = money.Length - 1; i >= 0; i--)
            {
                int quantity = getQuantity("ATM001", getMoneyId(money[i]));
                if (quantity > 0)
                    return money[i];
            }
            return 0;
        }

        private string customSheet(int mon)
        {
            int[] money = new int[] { 500000, 200000, 100000, 50000, 20000, 10000 };
            string ways = "";
            int total, countSheet;
            int mod = 0, currentMoney = 0, quantity = 0;
            bool checkTotal = true;
            int index = -1;

            total = mon;
            for (int i = 0; i < money.Length; i++)
            {
                countSheet = total / money[i];
                if (countSheet != 0)
                {
                    int tienChan = countSheet * money[i];
                    quantity = getQuantity("ATM001", getMoneyId(money[i]));
                    currentMoney = quantity * money[i];
                    if (money[i] > currentMoney)
                        continue;
                    else if (tienChan > currentMoney)   //kiểm tra số tiền còn trong DB
                    {
                        mod = total - currentMoney;
                        countSheet = currentMoney / money[i];
                        index = i;
                    }
                    else
                        mod = total - tienChan;
                    ways = countSheet + "-" + money[i];
                    if (mod == 0)
                        break;
                    else
                    {
                        String pence = "";
                        while (mod != 0 && checkTotal)
                        {
                            for (int j = 0; j < money.Length; j++)
                            {
                                countSheet = mod / money[j];
                                if (index == j)
                                {
                                    if(j == 5 && mod != 0)
                                    {
                                        checkTotal = false;
                                        break;
                                    }
                                    continue;
                                }
                                if (countSheet != 0)
                                {
                                    tienChan = countSheet * money[j];
                                    quantity = getQuantity("ATM001", getMoneyId(money[j]));
                                    currentMoney = quantity * money[j];
                                    if (money[j] > currentMoney)    //kiểm tra số tiền còn trong DB
                                    {
                                        if(j == 5 && mod != 0)
                                        {
                                            checkTotal = false;
                                            break;
                                        }
                                        continue;
                                    }
                                    else if (tienChan > currentMoney)
                                    {
                                        if (j == 5 && mod != 0)
                                        {
                                            checkTotal = false;
                                            break;
                                        }
                                        mod = mod - currentMoney;
                                        countSheet = currentMoney / money[j];
                                        index = j;
                                    }
                                    else
                                        mod -= tienChan;
                                    pence += "&" + countSheet + "-" + money[j];
                                }
                            }
                        }
                        ways += pence;
                        break;
                    }
                }
            }
            if (checkTotal && ways != "")
                return ways;
            else
                return "ErrorSystem";
        }

        private string getMoneyId(int money)
        {
            if (money == 10000)
                return "MONEY001";
            else if (money == 20000)
                return "MONEY002";
            else if (money == 50000)
                return "MONEY003";
            else if (money == 100000)
                return "MONEY004";
            else if (money == 200000)
                return "MONEY005";
            else if (money == 500000)
                return "MONEY006";
            else
                return "";
        }

        private int getQuantity(string atmID, string moneyID)
        {
            return stockDAL.getQuantity(atmID, moneyID);
        }
    }
}
