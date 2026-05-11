using ProFinancialTracking.UI;
using ProFinancialTracking.Services;

bool running = true;

while (running)
{
    Console.Clear();

    Console.WriteLine("================================");
    Console.WriteLine("PRO FINANCIAL TRACKING v1.0");
    Console.WriteLine("================================");

    MenuManager.DisplayMainMenu();

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            IncomeService.AddIncome();
            break;

        case "2":
            IncomeService.ViewIncomes();
            break;

        case "3":
            ExpenseService.AddExpense();
            break;

        case "4":
            ExpenseService.ViewExpenses();
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid Option.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}