using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public class TransactionExpense
    {
        private double expense;
        public void setExpense(double expense)
        {
            this.expense = expense;
        }
        public double getExpense()
        {
            return expense;
        }
    }
}
