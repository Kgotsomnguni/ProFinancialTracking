using ProFinancialTracking.Services;
using ProFinancialTracking.Helpers;
using ProFinancialTracking.Data;

namespace ProFinancialTracking.UI;

public static class DashBoardUI
{
    public static void DisplayDashBoard()
    {
        if (AppData.Incomes.Count == 0 && AppData.Expenses.Count == 0)
        {
            ConsoleHelper.DisplayHeader("PRO FINANCIAL TRACKING");
            Console.WriteLine("Welcome to Pro Financial Tracking!");

            Console.WriteLine();
            Console.WriteLine("No financial records available yet.");
            Console.WriteLine();
            Console.WriteLine("Start by Adding income and expense Budgets.");
            Console.WriteLine();
            Console.WriteLine("Press Enter TO Continue...");
            Console.ReadLine();
            return;
        }
        Console.Clear();

        decimal totalIncomeBudget = BudgetService.GetTotalIncomeBudget();
        decimal totalExpenseBudget = BudgetService.GetTotalExpenseBudget();
        decimal remainingBalance = BudgetService.GetRemainingBalance();

        decimal savingsRate = BudgetService.GetSavingsRate();
        string financialHealth = BudgetService.GetFinancialHealth();

        ConsoleHelper.DisplayHeader("PRO FINANCIAL TRACKING DASHBOARD");

        Console.WriteLine($"Budget Income       :R{totalIncomeBudget:N2}");
        Console.WriteLine($"Budget expenses       :R{totalExpenseBudget:N2}");
        Console.WriteLine();
        Console.WriteLine($"Remaining Balance       :R{remainingBalance:N2}");
        Console.WriteLine($"Savings Rate            :{savingsRate:N2}%");
        Console.WriteLine($"Financial Health       :R{financialHealth}");

        Console.WriteLine();

        ConsoleHelper.DisplaySeparator();
        Console.WriteLine("Press Enter to continue");

        Console.ReadLine();



    }
}
