using ProFinancialTracking.Helpers;
using ProFinancialTracking.Services;

namespace ProFinancialTracking.UI;

public static class StatisticsUI
{
    public static void DisplayExpenseStatistics()
    {
        


        Console.Clear();

        ConsoleHelper.DisplayHeader(
            "EXPENSE STATISTICS");

            var highestExpense = StatisticsService.GetHighestExpense();
        var lowestExpense = StatisticsService.GetLowestExpense();
        
        //DISPLAYING HIGHEST AND LOWEST EXPENSES
        if(highestExpense != null)
        {
            Console.WriteLine($"Highest Expense: {highestExpense.Name}");
            Console.WriteLine($"Amount: {highestExpense.BudgetAmount:N2}");
        }
        if(lowestExpense != null)
        {
            Console.WriteLine($"Lowest Expense: {lowestExpense.Name}");
            Console.WriteLine($"Amount: {lowestExpense.BudgetAmount:N2}");
        }

        Console.WriteLine();
        Console.WriteLine($"Average Expense: {StatisticsService.GetAverageExpense():N2}");

        Console.WriteLine();
        Console.WriteLine("Top Expenses:");
        ConsoleHelper.DisplaySeparator();

        var topExpenses = StatisticsService.GetTopExpenses();
        for(int i = 0; i < topExpenses.Count; i++)
        {
            var expense = topExpenses[i];
            Console.WriteLine($"{i + 1}. {topExpenses[i].Name} - {topExpenses[i].BudgetAmount:N2}");
        }
    }



}