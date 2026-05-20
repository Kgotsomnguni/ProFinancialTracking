using ProFinancialTracking.Models;
using ProFinancialTracking.Data;
using ProFinancialTracking.Helpers;

namespace ProFinancialTracking.Services;

public static class IncomeService
{
    public static void AddIncome()
    {
        Console.Clear();

        Console.WriteLine("===== ADD INCOME =====");

        Income income = new();

        income.Name =
            InputHelper.GetRequiredString("Income Name: ");

        income.BudgetAmount =
            InputHelper.GetDecimalInput("Budget Amount: ");

        income.ActualAmount =
            InputHelper.GetDecimalInput("Actual Amount: ");

        income.Frequency =
            InputHelper.GetRequiredString("Frequency: ");

        income.Date = DateTime.Now;

        AppData.Incomes.Add(income);

        FileManager.SaveData();

        Console.WriteLine();
        Console.WriteLine("Income Added Successfully.");
    }

    public static void ViewIncomes()
    {
        Console.Clear();

        Console.WriteLine("===== ALL INCOMES =====");

        if (AppData.Incomes.Count == 0)
        {
            Console.WriteLine("No incomes found.");
            return;
        }

        foreach (var income in AppData.Incomes)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Name: {income.Name}");
            Console.WriteLine($"Budget: R{income.BudgetAmount}");
            Console.WriteLine($"Actual: R{income.ActualAmount}");
            Console.WriteLine($"Frequency: {income.Frequency}");
            Console.WriteLine($"Date: {income.Date}");
        }
    }

    public static void EditIncome()
    {
        Console.Clear();
        ViewIncomes();

        if (AppData.Incomes.Count == 0)
            return;

        Console.WriteLine();

        int index = InputHelper.GetIntInput("Enter Income index to edit");

        if (index < 0 || index >= AppData.Incomes.Count)
        {
            Console.WriteLine("invalid index");
            return;
        }

        Income income = AppData.Incomes[index];
        Console.WriteLine();
        Console.WriteLine("Leave field empty to keep current value.");
        Console.WriteLine($"Name ({income.Name}): ");
        string name = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(name))
            income.Name = name;

        Console.Write($"Budget Amount ({income.BudgetAmount}): ");
        string budgetInput = Console.ReadLine() ?? "";

        if (decimal.TryParse(budgetInput, out decimal budget))
            income.BudgetAmount = budget;

        Console.Write($"Actual Amount ({income.ActualAmount}): ");
        string actualInput = Console.ReadLine() ?? "";

        if (decimal.TryParse(actualInput, out decimal actual))
            income.ActualAmount = actual;

        Console.Write($"Frequency ({income.Frequency}): ");
        string frequency = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(frequency))
            income.Frequency = frequency;

        FileManager.SaveData();

        Console.WriteLine();
        Console.WriteLine("Income updated successfully.");
    }

    public static void DeleteIncome()
    {
        Console.Clear();
        ViewIncomes();

        if (AppData.Incomes.Count == 0)
            return;
        Console.WriteLine();

        int index = InputHelper.GetIntInput("Enter Income index to delete: ");

        if (index < 0 || index >= AppData.Incomes.Count)
        {
            Console.WriteLine("Invalid index");
        }
        Income income = AppData.Incomes[index];
        Console.WriteLine();
        Console.WriteLine($"Are you sure you want to delete '{income.Name}' ?");

        Console.Write("Type YES to confirm: ");

        string confirmation = Console.ReadLine() ?? "";

        if (confirmation.ToUpper() == "YES")
        {
            AppData.Expenses.RemoveAt(index);

            FileManager.SaveData();

            Console.WriteLine("Income Deleted");
        }
        else
        {
            Console.WriteLine("Delete cancelled");
        }

    }
}