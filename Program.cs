using ProFinancialTracking.UI;
using ProFinancialTracking.Services;
using ProFinancialTracking.Helpers;

bool running = true;
FileManager.LoadData();

while (running)
{
    ConsoleHelper.DisplayHeader("PRO FINANCIAL TRACKING V1.0");

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

    ConsoleHelper.Pause();
}