using ProFinancialTracking.UI;
using ProFinancialTracking.Services;
using ProFinancialTracking.Helpers;
using System.Security.Cryptography.X509Certificates;

bool running = true;
StartUpUI.ShowStartUpScreen();
FileManager.LoadData();
DashBoardUI.DisplayDashBoard();

while (running)
{
    ConsoleHelper.DisplayHeader("PRO FINANCIAL TRACKING V1.0");

    MenuManager.DisplayMainMenu();

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            ShowIncomeMenu();
            break;

        case "2":
            ShowExpenseMenu();
            break;

        case "3":
            ShowReportsMenu();
            break;

        case "4":
            ShowGoalsMenu();
            break;

        case "5":
            running = false;
            break;



    }

    ConsoleHelper.Pause();

    static void ShowIncomeMenu()
    {

        while (true)
        {
            string choice = Console.ReadLine() ?? "";

            Console.Clear();
            MenuManager.DisplayIncomeMenu();

            switch (choice)
            {
                case "1":
                    IncomeService.AddIncome();
                    break;
                case "2":
                    IncomeService.ViewIncomes();
                    break;
                case "3":
                    IncomeService.EditIncome();
                    break;
                case "4":
                    IncomeService.DeleteIncome();
                    break;
                case "5": return;

            }

        }
    }

    static void ShowExpenseMenu()
    {
        while (true)
        {
            Console.Clear();
            MenuManager.DisplayExpensesMenu();

            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    ExpenseService.AddExpense();
                    break;
                case "2":
                    ExpenseService.ViewExpenses();
                    break;
                case "3":
                    ExpenseService.EditExpense();
                    break;
                case "4":
                    ExpenseService.DeleteExpense();
                    break;
                case "5":
                    ExpenseService.SearchExpenses();
                    break;
                case "6":
                    ExpenseService.FilterByCategory();
                    break;
                case "7":
                    ExpenseService.SortByExpenseAmount();
                    break;
                case "8": return;

            }
        }
    }
    static void ShowGoalsMenu()
    {
        while (true)
        {
            string choice = Console.ReadLine() ?? "";
            Console.Clear();
            MenuManager.DisplayGoalsMenu();

            switch (choice)
            {
                case "1":
                    GoalService.AddGoal();
                    break;
                case "2":
                    GoalService.ViewGoals();
                    break;
                case "3":
                    GoalService.ViewGoals();
                    break;
                case "4": return;


            }
        }
    }
    static void ShowReportsMenu()
    {
        while (true)
        {
            string choice = Console.ReadLine() ?? "";

            Console.Clear();
            MenuManager.DisplayReportsMenu();

            switch (choice)
            {
                case "1":
                    SummaryUI.DisplayFinancialSummary();
                    break;

                case "2":
                    ReportUI.DisplayMonthlyReport();
                    break;

                case "3":
                    ReportExportService.ExportMonthlyReport();
                    break;
                case "4": StatisticsUI.DisplayExpenseStatistics();
                    break;
                case "5": return;
            }
        }
    }

}


