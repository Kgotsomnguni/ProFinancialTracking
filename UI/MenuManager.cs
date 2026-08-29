using ProFinancialTracking.Helpers;

namespace ProFinancialTracking.UI;

public static class MenuManager
{
    public static void DisplayMainMenu()
    {


        ConsoleHelper.DisplayHeader("PRO FINANCIAL TRACKING V1.1.0");
        ConsoleHelper.DisplaySection("MAIN MENU");
        Console.WriteLine("1. Income Management");
        Console.WriteLine("2. Expense Management");
        Console.WriteLine("3. Reports and Analysis");
        Console.WriteLine("4. Savings Goals");
        Console.WriteLine("5. Exit");

    }

    public static void DisplayIncomeMenu()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader("INCOME MANAGEMENT");

        Console.WriteLine("1. Add Income");
        Console.WriteLine("2. ViewIncomes");
        Console.WriteLine("3. Edit Income");
        Console.WriteLine("4. Delete Income");
        Console.WriteLine("5. Back");

    }
    public static void DisplayExpensesMenu()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader("EXPENSE MANAGEMENT");

        Console.WriteLine("1. Add Expense");
        Console.WriteLine("2. View Expenses");
        Console.WriteLine("3. Edit Expense");
        Console.WriteLine("4. Delete Expenses");
        Console.WriteLine("5. Search Expenses");
        Console.WriteLine("6. Filter Expenses");
        Console.WriteLine("7. Sort Expenses");
        Console.WriteLine("8. Back");
    }

    public static void DisplayReportsMenu()
    {
        Console.Clear();
        ConsoleHelper.DisplayHeader("REPORTS AND ANALYSIS");
        Console.WriteLine("1. Financial Summary");
        Console.WriteLine(" 2. Monthly Report");
        Console.WriteLine(" 3. Export Monthly Report");
        Console.WriteLine(" 4. Expense Statistics");
        Console.WriteLine(" 5. Financial Health Score");
        Console.WriteLine(" 6. Category Spending Analysis");
        Console.WriteLine(" 7. Budget Forecast");
        Console.WriteLine(" 8. Back");


        Console.WriteLine();

    }
    public static void DisplayGoalsMenu()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader("SAVINGS GOALS");

        Console.WriteLine("1. Add Goal");
        Console.WriteLine("2. View Goal");
        Console.WriteLine("3. Update Goal");
        Console.WriteLine("4. Back");

    }
}