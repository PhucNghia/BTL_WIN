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

        public string ConfigID { get => configID; set => configID = value; }
        public string DateModified { get => dateModified; set => dateModified = value; }
        public decimal MinWithDraw { get => minWithDraw; set => minWithDraw = value; }
        public decimal MaxWithDraw { get => maxWithDraw; set => maxWithDraw = value; }
        public int NumPerPage { get => numPerPage; set => numPerPage = value; }
    }
}
