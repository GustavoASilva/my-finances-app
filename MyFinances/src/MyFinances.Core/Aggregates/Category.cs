namespace MyFinances.Core.SyncedAggregates
{
    public class Category
        : Enumeration
    {
        public static Category Market = new Category(1, "Mercado");
        public static Category Food = new Category(2, "Alimentação");
        public static Category Others = new Category(3, "Outros");

        public Category(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<Category> List() =>
            new[] { Market, Food, Others };
    }
}