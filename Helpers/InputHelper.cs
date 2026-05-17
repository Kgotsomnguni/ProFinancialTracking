namespace ProFinancialTracking.Helpers;

public static class InputHelper
{

    public static decimal GetDecimalInput(string prompt)
    {
        decimal value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            bool isValid = decimal.TryParse(input, out value);
            if (isValid)
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid decimal number.");
        }
    }

    public static int GetIntInput(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            bool isValid = int.TryParse(input, out value);
            if (isValid)
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
    public static string GetRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("Input cannot be empty. Please enter a valid string.");
        }

    }
}