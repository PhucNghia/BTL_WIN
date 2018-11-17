﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class OverDraftDTO
    {
        private string oDID;
        private decimal value;

        public OverDraftDTO()
        {

        }

        public OverDraftDTO(string oDID, decimal value)
        {
            this.oDID = oDID;
            this.value = value;
        }

        public string ODID { get => oDID; set => oDID = value; }
        public decimal Value { get => value; set => this.value = value; }
    }
}