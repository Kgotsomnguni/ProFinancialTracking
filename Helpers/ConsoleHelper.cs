namespace ProFinancialTracking.Helpers;

public static class ConsoleHelper
{
    public static void DisplayHeader(string title)
    {
         Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine(title.ToUpper());
        Console.WriteLine("================================");
        Console.WriteLine();
    }

    public static void DisplaySeparator()
    {
         Console.WriteLine("--------------------------------");
    }
    public static void Pause()
    {
         Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}