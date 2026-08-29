using Microsoft.VisualBasic;

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

        while (true )
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
    public static void CheckKeyPress()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.Escape)
        {
            return;
        }
    }
    
    public static bool GetConfirmation(string message)
{
    Console.Write($"{message} (Y/N): ");

    string input =
        Console.ReadLine()?.Trim().ToUpper() ?? "";

    return input == "Y";
}

public static string? GetInput(string prompt)
{
    Console.Write(prompt);

    string input = "";

    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Escape)
        {
            Console.WriteLine();
            return null;
        }

        if (key.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            return input;
        }

        if (key.Key == ConsoleKey.Backspace)
        {
            if (input.Length > 0)
            {
                input = input[..^1];
                Console.Write("\b \b");
            }

            continue;
        }

        if (!char.IsControl(key.KeyChar))
        {
            input += key.KeyChar;
            Console.Write(key.KeyChar);
        }
    }
}



}