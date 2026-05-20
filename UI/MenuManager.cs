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
        Console.WriteLine("6. Search Expenses");
        Console.WriteLine("7. Filter by Category");
        Console.WriteLine("8. Sort Expenses by Amount");
        Console.WriteLine("9. Exit");
        Console.WriteLine("======================");
        Console.WriteLine("Select an option: ");
    }
}