using ProFinancialTracking.Helpers;

namespace ProFinancialTracking.UI;

public static class MenuManager
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine();
        ConsoleHelper.DisplayHeader("MAIN MENU");
        Console.WriteLine("1. Add Income");
        Console.WriteLine("2. View Income");
        Console.WriteLine("3. Add Expense");
        Console.WriteLine("4. View Expense");
        Console.WriteLine("5. Financial Summary");
        Console.WriteLine("6. Edit Expense");
        Console.WriteLine("7. Delete Expense");
        Console.WriteLine("8. Edit Income ");
        Console.WriteLine("9. Delete Income");
        Console.WriteLine("10. Search Expenses");
        Console.WriteLine("11. Filter By Category ");
        Console.WriteLine("12. Sort Expenses By Amount ");
        Console.WriteLine("13. Exit ");
        Console.WriteLine("Select an option: ");


    }
}