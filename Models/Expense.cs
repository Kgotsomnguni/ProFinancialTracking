namespace ProFinancialTracking.Models
{
    public class Expense
    {
        public string Name { get; set; } = string.Empty;
        public decimal BudgetAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int Importance { get; set; }
        public bool ActualEntered { get; set; }
    }

}