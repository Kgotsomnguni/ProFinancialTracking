using ProFinancialTracking.Helpers;
using ProFinancialTracking.Services;
using ProFinancialTracking.Data;

namespace ProFinancialTracking.UI;

public static class CategoryAnalysisUI
{
    public static void DisplayCategoryAnalysis()
    {
        
        Console.Clear();

        ConsoleHelper.DisplayHeader(
            "CATEGORY SPENDING ANALYSIS");
            if (AppData.Expenses.Count == 0)
{
    Console.WriteLine("No expense data available.");
    Console.WriteLine("Please add expenses before viewing category analysis.");
    return;
}

        var totals = CategoryAnalysisService.GetCategoryTotals();
        var percentages = CategoryAnalysisService.GetCategoryPercentages();

        foreach (var category in totals)
        {
            Console.WriteLine(
                $"{category.Key}");

            Console.WriteLine(
                $"Amount: R{category.Value:N2}");

            Console.WriteLine(
                $"Percentage: {percentages[category.Key]:N2}%");

            Console.WriteLine();

            ConsoleHelper.DisplaySeparator();
        }

        var highestCategory = totals.OrderByDescending(c => c.Value).FirstOrDefault();

        Console.WriteLine();

        Console.WriteLine(
            $"Largest Spending Category: {highestCategory.Key}");

        Console.WriteLine(
            $"Amount: R{highestCategory.Value:N2}");
    }
}