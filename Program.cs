using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace OOP_Assignment
{
    public class Welcome
    {
        public void WelcomeMessage()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Finance Tracker");
            Console.WriteLine("===============");

        }
    }

    public class Option

    {
        public void OptionMenu()
        {
            Console.WriteLine("\n1. Add Income");
            Console.WriteLine("2. Expenses");
            Console.WriteLine("3. View Account");
            Console.WriteLine("4. View Transaction History");
            Console.WriteLine("5. Quit");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            string user_input;
            char user_option = default;
            double user_income;
            double user_expense;

            double total_income = default;
            double total_expense = default;

            double user_account = default;

            int counter = default;


            Welcome WelcomeMessage = new Welcome();
            Option OptionMenu = new Option();

            TransactionIncome TransactionIncome = new TransactionIncome();
            TransactionDate TransactionDate = new TransactionDate();

            List<TransactionIncome> transactionIncomes = new List<TransactionIncome>();
            List<TransactionDate> transactionDatesIncomes = new List<TransactionDate>();

            List<TransactionExpense> transactionExpenses = new List<TransactionExpense>();
            List<TransactionDate> transactionDatesExpenses = new List<TransactionDate>();

            WelcomeMessage.WelcomeMessage();


            bool InputValidation(string user_input)
            {
                if (user_input == "1" || user_input == "2" || user_input == "3" || user_input == "4" || user_input == "5")
                {
                    user_option = Convert.ToChar(user_input);
                    return true;
                }
                else
                {
                    Console.WriteLine("Please select a valid option (1-5)!");
                    return false;
                }
            }

            bool IncomeValidation(string user_input)
            {
                if (Double.TryParse(user_input,out user_income) == true)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return false;
                }
            }

            bool ExpenseValidation(string user_input)
            {
                if (Double.TryParse(user_input, out user_expense) == true)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return false;
                }
            }

            void AddIncome()
            {
                do
                {
                    Console.WriteLine("Please enter your income: ");
                    user_input = Console.ReadLine();
                } while (IncomeValidation(user_input) == false);
            }

            void AddExpenses()
            {
                do
                {
                    Console.WriteLine("Please enter your expense: ");
                    user_input = Console.ReadLine();
                } while (ExpenseValidation(user_input) == false);
            }

            double ViewAccount()
            {
                user_account = Math.Round(total_income - total_expense, 2);
                return user_account;
            }

            void ViewTransactionHistory()
            {
                if (counter == 0)
                {
                    Console.WriteLine("No history available");
                }
                else
                {
                    Console.WriteLine("{0, -10} {1, -25} {2, -10} {3, -25 }", "Income", "Transaction Date", "Expense", "Transaction Date");
                    for (int i = 0; i < counter; i++)
                    {
                        string incomeVal;
                        string incomeDate;

                        string expenseVal;
                        string expenseDate;

                        if (i < transactionIncomes.Count)
                        {
                            incomeVal = Convert.ToString(transactionIncomes[i].getIncome());
                            incomeDate = Convert.ToString(transactionDatesIncomes[i].getDate());
                        }
                        else
                        {
                            incomeVal = "";
                            incomeDate = "";
                        }
                        if (i < transactionExpenses.Count)
                        {
                            expenseVal = Convert.ToString(transactionExpenses[i].getExpense());
                            expenseDate = Convert.ToString(transactionDatesExpenses[i].getDate());
                        }
                        else
                        {
                            expenseVal = "";
                            expenseDate = "";
                        }
                        Console.WriteLine("{0, -10} {1, -25} {2, -10} {3, -25 }", incomeVal, incomeDate, expenseVal, expenseDate);
                    }
                }

            
            }

            while (true)
            {
                OptionMenu.OptionMenu();
                do
                {
                    Console.WriteLine("\nPlease select an option (1-5): ");
                    user_input = Console.ReadLine();
                }
                while (InputValidation(user_input) == false);
                switch(user_option)
                {
                    case '1':
                        AddIncome();

                        TransactionIncome newTransactionIncome = new TransactionIncome();
                        TransactionDate newTransactionDateIncome = new TransactionDate();

                        newTransactionIncome.setIncome(user_income);
                        newTransactionDateIncome.setDate(DateTime.Now);

                        transactionIncomes.Add(newTransactionIncome);
                        transactionDatesIncomes.Add(newTransactionDateIncome);

                        total_income += newTransactionIncome.getIncome();

                        counter += 1;
                        break;
                    case '2':
                        AddExpenses();

                        TransactionExpense newTransactionExpense = new TransactionExpense();
                        TransactionDate newTransactionDateExpense = new TransactionDate();

                        newTransactionExpense.setExpense(user_expense);
                        newTransactionDateExpense.setDate(DateTime.Now);

                        transactionExpenses.Add(newTransactionExpense);
                        transactionDatesExpenses.Add(newTransactionDateExpense);

                        total_expense += newTransactionExpense.getExpense();

                        counter += 1;
                        break;
                    case '3':
                        Console.WriteLine("\nYour account balance: " + ViewAccount());
                        break;
                    case '4':
                        ViewTransactionHistory();
                        break;
                    case '5':
                        Console.WriteLine("\nQuitting Application...");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
