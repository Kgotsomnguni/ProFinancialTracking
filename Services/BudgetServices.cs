using System.Reflection.Metadata.Ecma335;
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

    public static decimal GetSavingsRate()
    {
        decimal income = GetTotalIncomeActual();
        decimal expenses = GetTotalExpenseActual();

        if(income == 0)
        return 0;

        decimal savings = income - expenses;
        return (savings / income) *100;

    }

    public static decimal GetExpensePercentage()
    {
        decimal income= GetTotalIncomeActual();
        decimal expenses = GetTotalExpenseActual();
        if(income == 0)
        return 0;

        return (expenses / income)* 100;
    }
    

    public static string GetHighestExpense()
    {
        if(AppData.Expenses.Count == 0)
        return "No Expenses";

        var highestExpense = AppData.Expenses.OrderByDescending(e => e.ActualAmount).First();

        return highestExpense.Name;
    }

    public static decimal GetHighestExpenseAmount()
    {
        if(AppData.Expenses.Count == 0)
        return 0 ;

        return AppData.Expenses.Max(e => e.ActualAmount);
    }

    public static string GetFinancialHealth()
    {
        
        decimal savingsRate = GetSavingsRate();

        if(savingsRate >= 40)
        return "Excellent";

        if(savingsRate >= 20)
        return "healthy";

        if(savingsRate >= 10)
        return "Moderate";

        if(savingsRate >=0)
        return "Risky";

        return "Critical";
    }
}
