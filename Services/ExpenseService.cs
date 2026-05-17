using ProFinancialTracking.Models;
using ProFinancialTracking.Data;

namespace ProFinancialTracking.Services;

public static class ExpenseService
{
    public static void AddExpense()
    {
        Console.Clear();

        Console.WriteLine("===== ADD EXPENSE =====");

        Expense expense = new();

        Console.Write("Expense Name: ");
        expense.Name = Console.ReadLine() ?? "";

        Console.Write("Budget Amount: ");
        expense.BudgetAmount = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Actual Amount: ");
        expense.ActualAmount = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Category: ");
        expense.Category = Console.ReadLine() ?? "";

        Console.Write("Frequency: ");
        expense.Frequency = Console.ReadLine() ?? "";

        Console.Write("Importance (1-5): ");
        expense.Importance = int.Parse(Console.ReadLine() ?? "1");

        AppData.Expenses.Add(expense);
        FileManager.SaveData();

        Console.WriteLine();
        Console.WriteLine("Expense Added Successfully.");
    }

    public static void ViewExpenses()
    {
        Console.Clear();

        Console.WriteLine("===== ALL EXPENSES =====");

        if (AppData.Expenses.Count == 0)
        {
            Console.WriteLine("No expenses found.");
            return;
        }

        foreach (var expense in AppData.Expenses)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Name: {expense.Name}");
            Console.WriteLine($"Budget: R{expense.BudgetAmount}");
            Console.WriteLine($"Actual: R{expense.ActualAmount}");
            Console.WriteLine($"Category: {expense.Category}");
            Console.WriteLine($"Frequency: {expense.Frequency}");
            Console.WriteLine($"Importance: {expense.Importance}");
        }
    }
}