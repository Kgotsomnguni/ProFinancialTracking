using ProFinancialTracking.Data;
using ProFinancialTracking.Models;

namespace ProFinancialTracking.Services;

public static class CategoryAnalysisService
{
    public static decimal GetTotalExpenseAmount()
    {
        return AppData.Expenses
            .Sum(e => e.BudgetAmount);
    }

    public static Dictionary<string, decimal> GetCategoryTotals()
    {
        return AppData.Expenses.GroupBy(e => string.IsNullOrWhiteSpace(e.Category) ? "uncategorized" : e.Category).ToDictionary(group => group.Key, group => group.Sum(expense => expense.BudgetAmount));

    }
    public static Dictionary<string, decimal>
        GetCategoryPercentages()
    {
        decimal total =
            GetTotalExpenseAmount();

        Dictionary<string, decimal>
            categoryTotals =
                GetCategoryTotals();

        return categoryTotals
            .ToDictionary(
                category => category.Key,
                category =>
                    total == 0
                    ? 0
                    : (category.Value / total) * 100);
    }
}
