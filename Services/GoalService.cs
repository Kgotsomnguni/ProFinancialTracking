using ProFinancialTracking.Models;
using ProFinancialTracking.Helpers;
using ProFinancialTracking.Data;
using ProFinancialTracking.Services;
using System.ComponentModel.Design.Serialization;

namespace ProFinancialTracking.Services;

public static class GoalService
{
    public static void AddGoal()
    {
        ConsoleHelper.DisplayHeader("Add Savings Goal");
        SavingsGoal goal = new();

        goal.Name = InputHelper.GetRequiredString("Goal Name: ");
        goal.TargetAmount = InputHelper.GetDecimalInput("Target Amount: ");

        goal.CurrentAmount = 0;
        AppData.Goals.Add(goal);
        FileManager.SaveData();

        Console.WriteLine();
        Console.WriteLine("Goal added successfully. ");
    }

    public static void ViewGoals()
    {
        ConsoleHelper.DisplayHeader("SAVINGS GOALS");

        if (AppData.Goals.Count == 0)
        {
            Console.WriteLine("No Goals available");
            return;
        }

        for (int i = 0; i < AppData.Goals.Count; i++)
        {
            var goal = AppData.Goals[i];
            decimal progress = (goal.CurrentAmount / goal.TargetAmount) * 100;


            Console.WriteLine($"Goal #{i}");
            Console.WriteLine($"Target: R{goal.Name:N2}");
            Console.WriteLine($"Current: R{goal.CurrentAmount:N2}");
            Console.WriteLine($"Progress: {progress:N2}");

            Console.WriteLine();
            if (progress >= 100)
            {
                Console.WriteLine("Status: Completed");
            }
            else
            {
                Console.WriteLine("Status: In Progress");
            }
        }
    }
    public static void UpdateGoal()
    {
        ViewGoals();
        if (AppData.Goals.Count == 0)
            return;

        int index = InputHelper.GetIntInput("Select goal index ");

        if (index < 0 || index >= AppData.Goals.Count)
        {
            Console.WriteLine("invalid index. ");
            return;
        }
        decimal amount = InputHelper.GetDecimalInput("Current Saved Amount: ");

        AppData.Goals[index].CurrentAmount = amount;
        Console.WriteLine("Goal updated. ");
    }


}