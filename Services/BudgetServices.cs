using ProFinancialTracking.Data;

namespace ProFinancialTracking.Services;

public static class BudgetService
{
    public static decimal GetTotalIncomeBudget()
    {

        return AppData.Incomes.Sum(i => i.BudgetAmount);
    }
    public static decimal GetTotalIncomeActual()
    {
        return AppData.Incomes.Sum(i => i.ActualAmount);
    }
    public static decimal GetTotalExpenseBudget()
    {
        return AppData.Expenses.Sum(e => e.BudgetAmount);
    }
    public static decimal GetTotalExpenseActual()
    {
        return AppData.Expenses.Sum(e => e.ActualAmount);
    }

    public static decimal GetRemainingBalance()
    {
        return GetTotalIncomeActual() - GetTotalExpenseActual();
    }
    public static decimal GetPercentage(decimal ExpenseTotal,decimal IncomeTotal)
    {
        decimal percentage = ((ExpenseTotal / IncomeTotal)*100);
        percentage = Math.Round(percentage,2);
        return percentage;
    }
}
