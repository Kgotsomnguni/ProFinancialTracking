using ProFinancialTracking.Models;
using ProFinancialTracking.Data;
using ProFinancialTracking.Helpers;


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

        for (int i = 0; i < AppData.Expenses.Count; i++)
        {
            var expense = AppData.Expenses[i];
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Index: {i}");
            Console.WriteLine($"Name: {expense.Name}");
            Console.WriteLine($"Budget: R{expense.BudgetAmount}");
            Console.WriteLine($"Actual: R{expense.ActualAmount}");
            Console.WriteLine($"Category: {expense.Category}");
            Console.WriteLine($"Frequency: {expense.Frequency}");
            Console.WriteLine($"Importance: {expense.Importance}");
        }
    }
    public static void SearchExpenses()
    {
        Console.Clear();

        Console.Write("Enter expense name to search: ");

        string keyword = Console.ReadLine() ?? "";

        var results = AppData.Expenses
        .Where(e => e.Name
        .ToLower()
        .Contains(keyword.ToLower()))
        .ToList();

        Console.WriteLine();

        if (results.Count == 0)
        {
            Console.WriteLine("No Matching expenses found.");
            return;
        }
        foreach (var expense in results)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Name: {expense.Name}");
            Console.WriteLine($"Amount: {expense.ActualAmount}");
            Console.WriteLine($"Category: {expense.Category}");
        }
    }

    public static void FilterByCategory()
    {
        Console.Clear();

        Console.Write("Enter Category");
        string category = Console.ReadLine() ?? "";

        var results = AppData.Expenses
        .Where(e => e.Category.ToLower() == category.ToLower()).ToList();

        Console.WriteLine();

        if (results.Count == 0)
        {
            Console.WriteLine("No expenses found in this category.");
            return;
        }

        foreach (var expense in results)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Name: {expense.Name}");
            Console.WriteLine($"Amount: R{expense.ActualAmount}");
            Console.WriteLine($"Importance: {expense.Importance}");
        }
    }
    public static void SortByExpenseAmount()
    {
        Console.Clear();

        var sortedExpenses = AppData.Expenses.OrderByDescending(e => e.ActualAmount).ToList();

        foreach (var expense in sortedExpenses)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Name: {expense.Name}");
            Console.WriteLine($"Amount: {expense.ActualAmount}");
            Console.WriteLine($"Category: {expense.Category}");

        }
    }

    public static void EditExpense()
    {
        Console.Clear();
        ViewExpenses();

        if (AppData.Expenses.Count == 0)
            return;

        Console.WriteLine();

        int index = InputHelper.GetIntInput("Enter Expense index to edit:");

        if (index < 0 || index >= AppData.Expenses.Count)
        {
            Console.WriteLine("invalid index");
            return;
        }

        Expense expense = AppData.Expenses[index];

        Console.WriteLine();
        Console.WriteLine("Leave field empty to keep current value.");

        Console.WriteLine($"Name ({expense.Name}): ");
        string name = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(name))
            expense.Name = name;

        Console.Write($"Budget Amount ({expense.BudgetAmount}): ");
        string budgetInput = Console.ReadLine() ?? "";

        if (decimal.TryParse(budgetInput, out decimal budget))
            expense.BudgetAmount = budget;

        Console.Write($"Actual Amount ({expense.ActualAmount}): ");
        string actualInput = Console.ReadLine() ?? "";

        if (decimal.TryParse(actualInput, out decimal actual))
            expense.ActualAmount = actual;

        Console.Write($"Category ({expense.Category}): ");
        string category = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(category))
            expense.Category = category;

        FileManager.SaveData();

        Console.WriteLine();
        Console.WriteLine("Expense updated successfully.");
    }
}
