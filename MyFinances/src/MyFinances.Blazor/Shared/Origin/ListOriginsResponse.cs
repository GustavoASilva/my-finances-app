namespace MyFinances.Blazor.Shared.Origin
{
    public class ListOriginsResponse
    {
        public ListOriginsResponse(List<OriginDto> origins)
        {
            Origins = origins;
        }

        public List<OriginDto> Origins { get; set; }
    }
}