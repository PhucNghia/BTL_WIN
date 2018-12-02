using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALs;

namespace BULs
{
    public class ConfigBUL
    {
        ConfigDAL configDAL = new ConfigDAL();
        public bool getMaxWithDraw(int money)
        {
            if (money > configDAL.getMaxWithDraw())
                return false;
            else
                return true;
        }
    }
}
