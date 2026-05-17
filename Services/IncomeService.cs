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
}