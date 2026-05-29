
using ProFinancialTracking.Services;
using ProFinancialTracking.Helpers;
using ProFinancialTracking.Data;


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


        // if there is income info then analysis can be done if not prompt user to add income and expense records
        if (AppData.Expenses.Count == 0 || AppData.Incomes.Count == 0)
        {
            Console.WriteLine("No records available please start by inserting records");
            return;
        }


        decimal highestExpenseAmount =
    BudgetService.GetHighestExpenseAmount();

        string financialHealth =
            BudgetService.GetFinancialHealth();


        Console.WriteLine("INCOME");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine($"Budget Income     : R{totalIncomeBudget:N2}");
        Console.WriteLine($"Actual Income     : R{totalIncomeActual:N2}");

        Console.WriteLine();

        Console.WriteLine("EXPENSES");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine($"Budget Expenses   : R{totalExpenseBudget:N2}");
        Console.WriteLine($"Actual Expenses   : R{totalExpenseActual:N2}");

        Console.WriteLine();

        Console.WriteLine("BALANCE");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine($"Remaining Balance : R{remainingBalance:N2}");

        Console.WriteLine();

        Console.WriteLine("STATUS");
        ConsoleHelper.DisplaySeparator();

        if (remainingBalance < 0)
        {
            Console.WriteLine("Financial Status  : ALERT - Negative Balance");
        }
        else
        {
            Console.WriteLine("Financial Status  : Positive Balance");
        }

        if (totalExpenseActual > totalExpenseBudget)
        {
            Console.WriteLine("Budget Status     : OVER BUDGET");
        }
        else
        {
            Console.WriteLine("Budget Status     : Within Budget");
        }

        Console.WriteLine();

        ConsoleHelper.DisplaySection("ANALYSIS");

        Console.WriteLine($"Savings Rate      : {savingsRate:N2}%");
        Console.WriteLine($"Expense Usage     : {expensePercentage:N2}%");

        Console.WriteLine();

        Console.WriteLine($"Highest Expense   : {highestExpense}");
        Console.WriteLine($"Amount            : R{highestExpenseAmount:N2}");

        Console.WriteLine();

        //Console.WriteLine($"Financial Health  : {financialHealth}");

        Console.WriteLine();

        Console.WriteLine("Budget Usage");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine(
            $"Actual Expenses use {BudgetService.GetPercentage(totalExpenseActual, totalIncomeActual):N2}% of actual income");

        Console.WriteLine(
            $"Budget Expenses use {BudgetService.GetPercentage(totalExpenseBudget, totalIncomeBudget):N2}% of budget income");



        ConsoleHelper.DisplaySection("RECOMMENDATIONS");

        if (expensePercentage > 80)
        {
            Console.WriteLine("- Expenses are consuming most of your income.");
        }

        if (savingsRate < 10)
        {
            Console.WriteLine("- Consider reducing non-essential spending.");
        }

        if (financialHealth == "Excellent")
        {
            Console.WriteLine("- Your financial health is excellent.");
        }

        if (remainingBalance > 0)
        {
            Console.WriteLine("- You still have money available for budgeting.");
        }

        if (remainingBalance < 0)
        {
            Console.WriteLine("- Review expenses and reduce spending.");
        }

    }

}