namespace MyFinances.Blazor.Shared.Origin
{
    public class CreateOriginRequest
    {
        public CreateOriginRequest(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; set; }
    }
}
