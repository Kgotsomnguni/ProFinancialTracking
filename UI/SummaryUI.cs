
using ProFinancialTracking.Services;
using ProFinancialTracking.Helpers;

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

        decimal savingsRate = BudgetService.GetSavingsRate();
        decimal expensePercentage = BudgetService.GetExpensePercentage();
        string highestExpense = BudgetService.GetHighestExpense();

        decimal highestExpenseAmount =
    BudgetService.GetHighestExpenseAmount();

        string financialHealth =
            BudgetService.GetFinancialHealth();


        ConsoleHelper.DisplayHeader("FINANCIAL SUMMARY");
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


        Console.WriteLine();
        ConsoleHelper.DisplayHeader("ANALYSIS");

        Console.WriteLine($"Savings Rate: {savingsRate:F2}:%");
        Console.WriteLine($"Expense Usage: {expensePercentage:F2}:%");

        Console.WriteLine($"Highest Expense: {highestExpense}");
        Console.WriteLine($"Highest Expense Amount: R{highestExpenseAmount}");
        Console.WriteLine($"Financial Health: {financialHealth}");



        ConsoleHelper.DisplayHeader(" RECOMMENDATIONS ");


        if (expensePercentage > 80)
        {
            Console.WriteLine(" - Your expenses are consuming most of your income.");
        }

        if (savingsRate < 10)
        {
            Console.WriteLine(" - Try reducing non-essential spending.");
        }

        if (financialHealth == "Excellent")
        {
            Console.WriteLine(
                "- Your financial health is excellent.");
        }
    }

}