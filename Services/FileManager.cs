using System.Text.Json;
using ProFinancialTracking.Data;
using ProFinancialTracking.Models;

namespace ProFinancialTracking.Services;

public static class FileManager
{
    private static readonly string incomeFilePath = "Data/incomes.json";

    private static readonly string expenseFilePath = "Data/expenses.json";
    private static readonly string goalFilePath = "Data/goals.json";

    public static void SaveData()
    {
        SaveIncomes();
        SaveExpenses();
        SaveGoals();
    }

    public static void LoadData()
    {
        LoadIncomes();
        LoadExpenses();
       LoadGoals();
    }

    private static void SaveIncomes()
    {
        string json = JsonSerializer.Serialize(
            AppData.Incomes,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(incomeFilePath, json);
    }

    private static void SaveExpenses()
    {
        string json = JsonSerializer.Serialize(
            AppData.Expenses,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(expenseFilePath, json);
    }
    private static void SaveGoals()
    {
        string json = JsonSerializer.Serialize(
            AppData.Goals,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(goalFilePath, json);
    }

    private static void LoadIncomes()
    {
        try
        {
            if (!File.Exists(incomeFilePath))
{
    return;
}

            string json = File.ReadAllText(incomeFilePath);

            Console.WriteLine("Income JSON Loaded:");
            Console.WriteLine(json);

            List<Income>? incomes =
                JsonSerializer.Deserialize<List<Income>>(json);

            if (incomes != null)
            {
                AppData.Incomes = incomes;

                Console.WriteLine($"Loaded {incomes.Count} incomes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Income Load Error: {ex.Message}");
        }
    }

    private static void LoadExpenses()
    {
        try
        {
 if (!File.Exists(goalFilePath))
{
    Console.WriteLine("Goal file not found.");
    return;
}

            string json = File.ReadAllText(expenseFilePath);

            Console.WriteLine("Expense JSON Loaded:");
            Console.WriteLine(json);

            List<Expense>? expenses =
                JsonSerializer.Deserialize<List<Expense>>(json);

            if (expenses != null)
            {
                AppData.Expenses = expenses;

                Console.WriteLine($"Loaded {expenses.Count} expenses.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expense Load Error: {ex.Message}");
        }
    }

    
    private static void LoadGoals()
{
    try
    {
        if (!File.Exists(goalFilePath))
        {
            Console.WriteLine("Goal file not found.");
            return;
        }

        string json = File.ReadAllText(goalFilePath);

        List<SavingsGoal>? goals =
            JsonSerializer.Deserialize<List<SavingsGoal>>(json);

        if (goals != null)
        {
            AppData.Goals = goals;

            Console.WriteLine($"Loaded {goals.Count} goals.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Goal Load Error: {ex.Message}");
    }
}
    
}
