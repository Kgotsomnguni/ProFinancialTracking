using ProFinancialTracking.UI;
using ProFinancialTracking.Services;

bool running = true;
FileManager.LoadData();

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
            SummaryUI.DisplayFinancialSummary();
            break;

        case "6":
            ExpenseService.EditExpense();
            break;

        case "7":
            ExpenseService.DeleteExpense();
            break;

        case "8":
            IncomeService.EditIncome();
            break;

        case "9":
            IncomeService.DeleteIncome();
            break;

        case "10":
            ExpenseService.SearchExpenses();
            break;

        case "11":
            ExpenseService.FilterByCategory();
            break;

        case "12":
            ExpenseService.SortByExpenseAmount();
            break;

        case "13":
            running = false;
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}