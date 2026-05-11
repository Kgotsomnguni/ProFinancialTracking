using ProFinancialTracking.Models;
 namespace ProFinancialTracking.Data;

public static class AppData
{
    public static List<Income> Incomes {get; set;} = new();
    public static List <Expense> Expenses {get; set;} = new();

}