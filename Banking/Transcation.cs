using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class Transcation
    {
        public int TranscationId { get; set; }
        public int FromAccountNumber { get; set; }
        public int ToAccountNumber { get; set; }
        public int Amount { get; set; }
        public DateTime TransacationDate { get; set; }
    }
}
