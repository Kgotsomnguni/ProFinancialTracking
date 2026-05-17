namespace ProFinancialTracking.UI;

public static class MenuManager
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=========== MAIN MENU ===========");
        Console.WriteLine("1. Add Income");
        Console.WriteLine("2. View Income");
        Console.WriteLine("3. Add Expense");
        Console.WriteLine("4. View Expense");
        Console.WriteLine("5. Financial Summary");
        Console.WriteLine("6. Exit");
        Console.WriteLine("======================");
        Console.WriteLine("Select an option: ");
    }
}