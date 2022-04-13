namespace MyFinances.Core.SyncedAggregates
{
    public class TransactionCategory
        : Enumeration
    {
        public static TransactionCategory Market = new TransactionCategory(1, "Mercado");
        public static TransactionCategory Food = new TransactionCategory(2, "Alimentação");
        public static TransactionCategory Others = new TransactionCategory(3, "Outros");

        public TransactionCategory(int id, string name)
            : base(id, name)
        {
        }

        public static List<TransactionCategory> List() =>
            new List<TransactionCategory> { Market, Food, Others };
    }
}