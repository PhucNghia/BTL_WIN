using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class LogTypeDTO
    {
        private string logTypeID;
        private string description;

        public LogTypeDTO()
        {

        }

        public LogTypeDTO(string logTypeID, string description)
        {
            this.logTypeID = logTypeID;
            this.description = description;
        }

        public string LogTypeID { get => logTypeID; set => logTypeID = value; }
        public string Description { get => description; set => description = value; }
    }
}
