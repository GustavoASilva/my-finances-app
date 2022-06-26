namespace MyFinances.Core.SyncedAggregates
{
    public class TransactionCategory : Enumeration
    {
        public static TransactionCategory Market = new TransactionCategory(1, "Mercado");
        public static TransactionCategory Food = new TransactionCategory(2, "Refeição");
        public static TransactionCategory Pets = new TransactionCategory(3, "Pets");
        public static TransactionCategory Investments = new TransactionCategory(4, "Investimentos");
        public static TransactionCategory Others = new TransactionCategory(5, "Outros");

        public TransactionCategory(int id, string name) : base(id, name)
        {
        }

        public static List<TransactionCategory> List() => new List<TransactionCategory> { Market, Food, Pets, Others };
    }
}