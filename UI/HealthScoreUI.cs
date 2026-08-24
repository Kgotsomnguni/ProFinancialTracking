using ProFinancialTracking.Helpers;
using ProFinancialTracking.Services;

namespace ProFinancialTracking.UI;

public static class HealthScoreUI
{
    public static void DisplayHealthScore()
    {
        Console.Clear();

        ConsoleHelper.DisplayHeader(
            "FINANCIAL HEALTH SCORE");

        string score =
            HealthScoreService.GetHealthScore();

        Console.WriteLine();

        Console.WriteLine(
            $"Current Score: {score}");

        Console.WriteLine(); 
        switch(score)
{
    case "Excellent":
        Console.WriteLine(
            "Excellent financial position.");
        break;

    case "Good":
        Console.WriteLine(
            "Good financial habits.");
        break;

    case "Fair":
        Console.WriteLine(
            "Room for improvement.");
        break;

    case "Poor":
        Console.WriteLine(
            "Reduce expenses and increase savings.");
        break;

    case "Critical":
        Console.WriteLine(
            "Immediate financial attention required.");
        break;
}

        }
        
}