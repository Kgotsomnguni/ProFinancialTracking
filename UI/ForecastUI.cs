using ProFinancialTracking.Helpers;
using ProFinancialTracking.Services;

namespace ProFinancialTracking.UI;

public static class ForecastUI
{
    public static void DisplayForecast()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader(
            "BUDGET FORECAST");

        decimal income =
            BudgetService.GetTotalIncomeBudget();

        decimal expenses =
            BudgetService.GetTotalExpenseBudget();

        decimal projected =
            ForecastService.GetProjectedBalance();

        Console.WriteLine(
            $"Current Budget Income   : R{income:N2}");

        Console.WriteLine(
            $"Current Budget Expenses : R{expenses:N2}");

        Console.WriteLine();

        Console.WriteLine(
            $"Remaining Budget        : R{income - expenses:N2}");

        Console.WriteLine();

        Console.WriteLine(
            $"Projected End Balance   : R{projected:N2}");

        Console.WriteLine();

        Console.WriteLine(
            $"Forecast Status         : {ForecastService.GetForecastStatus()}");

        Console.WriteLine();

        ConsoleHelper.DisplaySection("RECOMMENDATION");

        Console.WriteLine(
            ForecastService.GetForecastRecommendation());
    }
}