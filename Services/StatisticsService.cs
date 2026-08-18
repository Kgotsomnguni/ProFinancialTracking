using ProFinancialTracking.Data;
using ProFinancialTracking.Models;

namespace ProFinancialTracking.Services;

public static class StatisticsService
{
    
    public static Expense? GetHighestExpense()
    {
        if(AppData.Expenses.Count ==0)
        return null;
        return AppData.Expenses.OrderByDescending(e => e.BudgetAmount).FirstOrDefault();
    }

    public static Expense? GetLowestExpense()
    {
        if(AppData.Expenses.Count ==0)
        return null;
        return AppData.Expenses.OrderBy(e => e.BudgetAmount).FirstOrDefault();
    }

   public static decimal GetAverageExpense()
    {
        if(AppData.Expenses.Count ==0)
        return 0;
        return AppData.Expenses.Average(e => e.BudgetAmount);
    }
    public static decimal GetTotalExpense()
    {
        if(AppData.Expenses.Count ==0)
        return 0;
        return AppData.Expenses.Sum(e => e.BudgetAmount);
    }

    public static List<Expense> GetTopExpenses(int count = 5)
    {
        return AppData.Expenses.OrderByDescending(e => e.BudgetAmount).Take(count).ToList();
    }
}