using ProFinancialTracking.Models;
using ProFinancialTracking.Data;
using ProFinancialTracking.Helpers;


namespace ProFinancialTracking.Services;

public static class ExpenseService
{
    public static void AddExpense()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader("Add Expense");

        Expense expense = new();

        expense.Name =  InputHelper.GetRequiredString("Expense Name: ");

        expense.BudgetAmount = InputHelper.GetDecimalInput("Budget Amount: ");

        // Console.Write("Actual Amount: ");
        // expense.ActualAmount = decimal.Parse(Console.ReadLine() ?? "0");
        expense.ActualAmount = 0;
        expense.ActualEntered = false;

        expense.Category = InputHelper.GetRequiredString("Category: ");

        Console.Write("Frequency: ");
        expense.Frequency = Console.ReadLine() ?? "";

        Console.Write("Importance (1-5): ");
        // expense.Importance = int.Parse(Console.ReadLine() ?? "1");
        expense.Importance = InputHelper.GetIntInput("Importance (1-5)");

        while (expense.Importance < ApplicationConstants.MinImportanceLevel || expense.Importance > ApplicationConstants.MaxImportanceLevel)
        {
            Console.WriteLine(
                $"Importance must be between " +
                $"{ApplicationConstants.MinImportanceLevel} " +
                $"and {ApplicationConstants.MaxImportanceLevel}");

            expense.Importance = InputHelper.GetIntInput("Importance (1-5):");

        }

        AppData.Expenses.Add(expense);
        FileManager.SaveData();

        Console.WriteLine();
        Console.WriteLine("Expense Added Successfully.");
    }

    public static void ViewExpenses()
    {
        Console.Clear();

        //Console.WriteLine("===== ALL EXPENSES =====");
        //ConsoleHelper.DisplayHeader("ALL EXPENSES");


        if (AppData.Expenses.Count == 0)
        {
            Console.WriteLine("No expenses available yet.");
            Console.WriteLine("Start by Adding an expense");
            return;
        }

        for (int i = 0; i < AppData.Expenses.Count; i++)
        {
            DisplayExpense(AppData.Expenses[i], i);
        }
    }
    public static void SearchExpenses()
    {
        Console.Clear();
        if (AppData.Expenses.Count == 0)
        {
            Console.WriteLine("No expenses available yet.");
            Console.WriteLine("Start by Adding an expense");
            return;
        }

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
           Console.WriteLine($"Amount: R{expense.ActualAmount:N2}");
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
{
    expense.ActualAmount = actual;
    expense.ActualEntered = true;
}

        Console.Write($"Category ({expense.Category}): ");
        string category = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(category))
            expense.Category = category;

        Console.Write($"Frequency ({expense.Frequency}): ");
        string frequency = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(frequency))
            expense.Frequency = frequency;

        Console.Write($"Importance ({expense.Importance}): ");
        string importanceInput = Console.ReadLine() ?? "";

        if (int.TryParse(importanceInput, out int importance))
        {
            if (importance >= ApplicationConstants.MinImportanceLevel && importance <= ApplicationConstants.MaxImportanceLevel)
            {
                expense.Importance = importance;
            }
            else
            {
                Console.WriteLine($"Importance must be between {ApplicationConstants.MinImportanceLevel} and {ApplicationConstants.MaxImportanceLevel}. Keeping previous value.");
            }
        }




        FileManager.SaveData();

        Console.WriteLine();
        Console.WriteLine("Expense updated successfully.");
    }

    public static void DeleteExpense()
    {
        Console.Clear();
        ViewExpenses();

        if (AppData.Expenses.Count == 0)
            return;
        Console.WriteLine();

        int index = InputHelper.GetIntInput("Enter expense index to delete: ");

        if (index < 0 || index >= AppData.Expenses.Count)
        {
            Console.WriteLine("Invalid index");
            return;
        }
        Expense expense = AppData.Expenses[index];
        Console.WriteLine();
        Console.WriteLine($"Are you sure you want to delete '{expense.Name}' ?");

        Console.Write("Type YES to confirm: ");

        string confirmation = Console.ReadLine() ?? "";

        if (confirmation.ToUpper() == "YES")
        {
            AppData.Expenses.RemoveAt(index);

            FileManager.SaveData();

            Console.WriteLine("Expense Deleted");
        }
        else
        {
            Console.WriteLine("Delete cancelled");
        }

    }

    private static void DisplayExpense(Expense expense, int index)
    {
        ConsoleHelper.DisplaySeparator();

        Console.WriteLine($"Index: {index}");
        Console.WriteLine($"Name: {expense.Name}");
        Console.WriteLine($"Budget: R{expense.BudgetAmount}");
        Console.WriteLine($"Actual: R{expense.ActualAmount}");
        Console.WriteLine($"Category: {expense.Category}");
        Console.WriteLine($"Frequency: {expense.Frequency}");
        Console.WriteLine($"Importance: {expense.Importance}");


Console.WriteLine("========================================");
    Console.WriteLine($"EXPENSE RECORD #{index}");
    Console.WriteLine("========================================");
    Console.WriteLine();

    Console.WriteLine($"Name            : {expense.Name}");
    Console.WriteLine($"Budget Amount   : R{expense.BudgetAmount:N2}");

    if (expense.ActualEntered)
    {
        Console.WriteLine($"Actual Amount   : R{expense.ActualAmount:N2}");
    }
    else
    {
        Console.WriteLine("Actual Amount   : Not Entered");
    }

    Console.WriteLine($"Category        : {expense.Category}");
    Console.WriteLine($"Frequency       : {expense.Frequency}");
    Console.WriteLine($"Importance      : {expense.Importance}");

    Console.WriteLine();

    if (expense.ActualEntered)
    {
        if (expense.ActualAmount > expense.BudgetAmount)
        {
            Console.WriteLine("Status          : Over Budget");
        }
        else
        {
            Console.WriteLine("Status          : Within Budget");
        }
    }
    else
    {
        Console.WriteLine("Status          : Awaiting Actual Entry");
    }

    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine();
    }

    // new methods before release 
}
