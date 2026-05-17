
using ProFinancialTracking.Services;

namespace ProFinancialTracking.UI;

public static class SummaryUI
{
    public static void DisplayFinancialSummary()
    {
        Console.Clear();

        decimal totalIncomeBudget = BudgetService.GetTotalIncomeBudget();
        decimal totalIncomeActual = BudgetService.GetTotalIncomeActual();

        decimal totalExpenseBudget = BudgetService.GetTotalExpenseBudget();
        decimal totalExpenseActual = BudgetService.GetTotalExpenseActual();

        decimal remainingBalance = BudgetService.GetRemainingBalance();


        Console.WriteLine("========== FINANCIAL SUMMARY ==========");
        Console.WriteLine($"Total Income Budget   :   R{totalIncomeBudget}");
        Console.WriteLine($"Total Income Actual   :   R{totalIncomeActual}");
        Console.WriteLine();

        Console.WriteLine($"Total Expense Budget   :   R{totalExpenseBudget}");
        Console.WriteLine($"Total Expense Actual   :   R{totalExpenseActual}");
       Console.WriteLine($"Expenses use {BudgetService.GetPercentage(totalExpenseActual, totalIncomeActual)}% of your income");

        if (totalExpenseActual > totalExpenseBudget)
        {
            Console.WriteLine("Warning: You exceeded your expense budget");
        }

        if (remainingBalance < 0)
        {
            Console.WriteLine("Alert: Your Balance is negative");
        }
        else if (remainingBalance > 0)
        {
            Console.WriteLine("Good: Your finances are positive");
        }


    }

}