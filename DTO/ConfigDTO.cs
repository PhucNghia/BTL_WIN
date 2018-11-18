using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ConfigDTO
    {
        private string configID;
        private string dateModified;
        private decimal minWithDraw;
        private decimal maxWithDraw;
        private int numPerPage;

        public string ConfigID
        {
            get
            {
                return configID;
            }

            set
            {
                configID = value;
            }
        }

        public string DateModified
        {
            get
            {
                return dateModified;
            }

            set
            {
                dateModified = value;
            }
        }

        public decimal MinWithDraw
        {
            get
            {
                return minWithDraw;
            }

            set
            {
                minWithDraw = value;
            }
        }

        public decimal MaxWithDraw
        {
            get
            {
                return maxWithDraw;
            }

            set
            {
                maxWithDraw = value;
            }
        }

        public int NumPerPage
        {
            get
            {
                return numPerPage;
            }

            set
            {
                numPerPage = value;
            }
        }

        public ConfigDTO()
        {

        }

        public ConfigDTO(string configID, string dateModified, decimal minWithDraw, decimal maxWithDraw, int numPerPage)
        {
            this.ConfigID = configID;
            this.DateModified = dateModified;
            this.MinWithDraw = minWithDraw;
            this.MaxWithDraw = maxWithDraw;
            this.NumPerPage = numPerPage;
        }

       
    }
}
