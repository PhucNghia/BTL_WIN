using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LogTypeDTO
    {
        private string logTypeID;
        private string description;

        public string LogTypeID
        {
            get
            {
                return logTypeID;
            }

            set
            {
                logTypeID = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public LogTypeDTO()
        {

        }

        public LogTypeDTO(string logTypeID, string description)
        {
            this.LogTypeID = logTypeID;
            this.Description = description;
        }

    }
}
