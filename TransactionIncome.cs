using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment
{
    public class TransactionIncome
    {
        private double income;
        public void setIncome(double income)
        {
            this.income = income;
        }
        public double getIncome()
        {
            return income;
        }
    }
}
