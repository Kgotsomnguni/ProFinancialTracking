using ProFinancialTracking.Services;
using ProFinancialTracking.Helpers;

namespace ProFinancialTracking.UI;

public static class ReportUI
{
    public static void DisplayMonthlyReport()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader("MONTHLY FINANCIAL REPORT");

        decimal incomeBudget =
        BudgetService.GetTotalIncomeBudget();

        decimal incomeActual =
        BudgetService.GetTotalIncomeActual();

        decimal expenseBudget =
         BudgetService.GetTotalExpenseBudget();

        decimal expenseActual =
        BudgetService.GetTotalExpenseActual();

        decimal balance =
            BudgetService.GetRemainingBalance();

        decimal savingsRate =
            BudgetService.GetSavingsRate();

        decimal expenseUsage =
            BudgetService.GetExpensePercentage();

        string highestExpense =
            BudgetService.GetHighestExpense();

        string financialHealth =
            BudgetService.GetFinancialHealth();

        Console.WriteLine(
            $"Report Generated: {DateTime.Now}");
        // INCOME SECTIONS
        Console.WriteLine("INCOME");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine(
            $"Budget Income     : R{incomeBudget:N2}");

        Console.WriteLine(
            $"Actual Income     : R{incomeActual:N2}");

        Console.WriteLine();

        Console.WriteLine("EXPENSES");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine(
            $"Budget Expenses   : R{expenseBudget:N2}");

        Console.WriteLine(
            $"Actual Expenses   : R{expenseActual:N2}");

        Console.WriteLine();

        Console.WriteLine("BALANCE");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine(
            $"Remaining Balance : R{balance:N2}");

        Console.WriteLine();

        Console.WriteLine("ANALYSIS");
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine(
            $"Savings Rate      : {savingsRate:N2}%");

        Console.WriteLine(
            $"Expense Usage     : {expenseUsage:N2}%");

        Console.WriteLine(
            $"Highest Expense   : {highestExpense}");

        Console.WriteLine(
            $"Financial Health  : {financialHealth}");

        Console.WriteLine();

        Console.WriteLine(
           "========================================");

        Console.WriteLine(
            "END OF REPORT");

        Console.WriteLine(
            "========================================");
    }
}