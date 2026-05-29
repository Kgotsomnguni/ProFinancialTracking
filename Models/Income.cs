namespace ProFinancialTracking.Models;

public class Income
{
    public string Name { get; set; } = string.Empty;

    public decimal BudgetAmount { get; set; }

    public decimal ActualAmount { get; set; }

    public DateTime Date { get; set; }

    public string Frequency { get; set; } = string.Empty;
    public bool ActualEntered { get; set; }
}