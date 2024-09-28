using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public class TransactionDate
    {
        private DateTime transaction_date;

        public void setDate (DateTime transaction_date)
        {
            this.transaction_date = transaction_date;
        }

        public DateTime getDate()
        {
            return transaction_date;
        }
    }
}
