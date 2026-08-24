using ProFinancialTracking.Helpers;
namespace ProFinancialTracking.Services;

public static class ForecastService
{

    public static decimal GetProjectedBalance()
    {
        decimal income = BudgetService.GetTotalIncomeBudget();
        decimal expenses = BudgetService.GetTotalExpenseBudget();

        return income - expenses;
    }

    public static string GetForecastStatus()
    {
        decimal projected = GetProjectedBalance();

        if (projected < 0)
            return "Critical";

        if (projected == 0)
            return "Break Even";


        if (projected < 1000)
            return "Break-even";

        return "Healthy";
    }

    public static string GetForecastRecommendation()
{
    string status =
        GetForecastStatus();

    return status switch
    {
        "Healthy" =>
            "You are on track to remain within budget.",

        "Warning" =>
            "Monitor your spending closely for the rest of the month.",

        "Break Even" =>
            "Any additional spending may exceed your budget.",

        "Critical" =>
            "Reduce expenses immediately or increase income.",

        _ =>
            "No recommendation available."
    };
}
}
