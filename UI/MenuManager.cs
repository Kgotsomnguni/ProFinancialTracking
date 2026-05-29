using ProFinancialTracking.Helpers;

namespace ProFinancialTracking.UI;

public static class MenuManager
{
    public static void DisplayMainMenu()
    {


        ConsoleHelper.DisplayHeader("MAIN MENU");
        Console.WriteLine("1. Add Income");
        Console.WriteLine("2. View Income");
        Console.WriteLine("3. Edit Income");
        Console.WriteLine("4. Delete Income");

        ConsoleHelper.DisplaySection("Expenses");
        Console.WriteLine("5. Add Expense");
        Console.WriteLine("6. View Expense");
        Console.WriteLine("7. Edit Expense");
        Console.WriteLine("8. Delete Expense");

        ConsoleHelper.DisplaySection("Analysis");
        Console.WriteLine("9. Financial Summary");
        Console.WriteLine("10. Search Expenses");
        Console.WriteLine("11. Filter By Category ");
        Console.WriteLine("12. Sort Expenses By Amount ");

        ConsoleHelper.DisplaySection("System");
        Console.WriteLine("13. Exit ");



    }
}