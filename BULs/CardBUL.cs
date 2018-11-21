using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
    public class CardBUL
    {
        CardDAL cardDAL = new CardDAL();
        // Validate CardNo
        public bool checkCardNo(string cardNo)
        {
            return cardDAL.checkCardNo(cardNo);
        }

        public bool getExpiredDate(string cardNo)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            int currentYear = Convert.ToInt32(currentDate.Split('-')[0]);
            int currentMonth = Convert.ToInt32(currentDate.Split('-')[1]);
            int currentDay = Convert.ToInt32(currentDate.Split('-')[2]);

            int exYear = Convert.ToInt32(cardDAL.getExpiredDate(cardNo).Split('-')[0]);
            int extMonth = Convert.ToInt32(cardDAL.getExpiredDate(cardNo).Split('-')[1]);
            int exDay = Convert.ToInt32(cardDAL.getExpiredDate(cardNo).Split('-')[2]);

            if (currentYear > exYear)
            {
                return false;
            }
            else if (currentYear == exYear)
            {
                if (currentMonth > extMonth)
                {
                    return false;
                }
                else if (currentMonth < extMonth)
                {
                    return true;
                }
                else if (currentMonth == extMonth)
                {
                    if (currentDay > exDay)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        // Validate Pin
        public bool getStatus(string cardNo)
        {
            if (cardDAL.getStatus(cardNo).Equals("normal"))
                return true;
            else
                return false;
        }

        public void updateAttemptStatus(string card)
        {
            cardDAL.updateAttemptStatus(card);
        }

        public bool getPIN(string cardNo, string pin)
        {
            if (cardDAL.getPIN(cardNo).Equals(pin))
                return true;
            else
                return false;
        }
    }
}
