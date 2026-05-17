using ProFinancialTracking.Models;
using ProFinancialTracking.Data;

namespace ProFinancialTracking.Services;

public static class IncomeService
{
    public static void AddIncome()
    {
        Console.Clear();

        Console.WriteLine("===== ADD INCOME =====");

        Income income = new();

        Console.Write("Income Name: ");
        income.Name = Console.ReadLine() ?? "";

        Console.Write("Budget Amount: ");
        income.BudgetAmount = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Actual Amount: ");
        income.ActualAmount = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Frequency: ");
        income.Frequency = Console.ReadLine() ?? "";

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
}