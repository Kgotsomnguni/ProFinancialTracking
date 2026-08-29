using ProFinancialTracking.Models;
using ProFinancialTracking.Data;
using ProFinancialTracking.Helpers;

namespace ProFinancialTracking.Services;

public static class IncomeService
{
    public static void AddIncome()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader("ADD INCOME");

        Income income = new();

        string? name =
    InputHelper.GetInput("Income Name (ESC to cancel): ");

        if (name == null)
        {
            Console.WriteLine("Add income cancelled.");
            Console.WriteLine("Press any key to return to Income menu...");
            Console.ReadLine();
            return;
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Income name cannot be empty.");
            return;
        }

        income.Name = name;

        income.BudgetAmount =
            InputHelper.GetDecimalInput("Budget Amount: ");

        income.ActualAmount = 0;
        income.ActualEntered = false;

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

        ConsoleHelper.DisplayHeader("ALL INCOMES");


        if (AppData.Incomes.Count == 0)
        {
            Console.WriteLine("No incomes found.");
            return;
        }

        for (int i = 0; i < AppData.Incomes.Count; i++)
        {
            DisplayIncome(AppData.Incomes[i], i);
        }
        Console.ReadLine();
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
        Console.Write($"Name ({income.Name}): ");
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
        {
            income.ActualAmount = actual;
            income.ActualEntered = true;
        }

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
            return;
        }
        Income income = AppData.Incomes[index];
        Console.WriteLine();
        Console.WriteLine($"Are you sure you want to delete '{income.Name}' ?");

        Console.Write("Type YES to confirm: ");

        string confirmation = Console.ReadLine() ?? "";

        if (confirmation.ToUpper() == "YES")
        {
            AppData.Incomes.RemoveAt(index);

            FileManager.SaveData();

            Console.WriteLine("Income Deleted");
        }
        else
        {
            Console.WriteLine("Delete cancelled");
        }

    }

    //new methods before release
    private static void DisplayIncome(Income income, int index)
    {

        Console.WriteLine($"INCOME RECORD #{index}");

        Console.WriteLine();

        Console.WriteLine($"Name            : {income.Name}");
        Console.WriteLine($"Budget Amount   : R{income.BudgetAmount:N2}");

        if (income.ActualEntered)
        {
            Console.WriteLine($"Actual Amount   : R{income.ActualAmount:N2}");
        }
        else
        {
            Console.WriteLine("Actual Amount   : Not Entered");
        }

        Console.WriteLine($"Frequency       : {income.Frequency}");
        Console.WriteLine($"Date            : {income.Date:yyyy-MM-dd}");

        Console.WriteLine();
        ConsoleHelper.DisplaySeparator();
        Console.WriteLine();
    }

    // method created to alter input for when a user wants to go back


}