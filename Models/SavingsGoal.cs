namespace ProFinancialTracking.Models;

public class SavingsGoal
{
    public string Name { get; set; } = "";
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }

}