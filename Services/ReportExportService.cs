using ProFinancialTracking.Services;

namespace ProFinancialTracking.Services;

public static class ReportExportService
{
    public static void ExportMonthlyReport()
    {
        decimal incomeBudget =
    BudgetService.GetTotalIncomeBudget();

        decimal incomeActual =
            BudgetService.GetTotalIncomeActual();

        decimal expenseBudget =
            BudgetService.GetTotalExpenseBudget();

        decimal expenseActual =
            BudgetService.GetTotalExpenseActual();

        decimal balance =
            BudgetService.GetRemainingBalance();

        decimal savingsRate =
            BudgetService.GetSavingsRate();

        decimal expenseUsage =
            BudgetService.GetExpensePercentage();

        string highestExpense =
            BudgetService.GetHighestExpense();

        string financialHealth =
            BudgetService.GetFinancialHealth();

            string report = $@"
========================================
MONTHLY FINANCIAL REPORT
========================================

Generated:
{DateTime.Now}

INCOME
----------------------------------------
Budget Income     : R{incomeBudget:N2}
Actual Income     : R{incomeActual:N2}

EXPENSES
----------------------------------------
Budget Expenses   : R{expenseBudget:N2}
Actual Expenses   : R{expenseActual:N2}

BALANCE
----------------------------------------
Remaining Balance : R{balance:N2}

ANALYSIS
----------------------------------------
Savings Rate      : {savingsRate:N2}%
Expense Usage     : {expenseUsage:N2}%

Highest Expense   : {highestExpense}
Financial Health  : {financialHealth}

========================================
END OF REPORT
========================================
";

Directory.CreateDirectory("Reports");
string fileName =
    $"Reports/FinancialReport_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

    File.WriteAllText(fileName, report);


    Console.WriteLine();
Console.WriteLine(
    $"Report exported successfully.");

Console.WriteLine(
    $"Location: {fileName}");
    }
}