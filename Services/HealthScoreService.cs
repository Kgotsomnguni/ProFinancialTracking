using ProFinancialTracking.Services;

namespace ProFinancialTracking.Services
{
    public class HealthScoreService
    {
        // Implementation for health score calculation

        public static string GetHealthScore()
        {
            decimal SavingsRate = BudgetService.GetSavingsRate();
            decimal expenseUsage = BudgetService.GetExpensePercentage();
            decimal balance = BudgetService.GetRemainingBalance();

            if(balance <0)
            {
                return "critical";
            }
            if(SavingsRate >= 40 && expenseUsage <=60)
            {
                return "excellent";
            }
            else if(SavingsRate >= 25 && expenseUsage <=75)
            {
                return "good";
            }
            else if(SavingsRate >= 10 && expenseUsage <=90)
            {
                return "fair";
            }
            if(SavingsRate > 0)
            {
                return "critical";
            }
             return "poor";
        }
    }
}