using AutoMapper;
using MyFinances.Blazor.Shared.Recurrence;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.API.Profiles
{
    public class RecurrenceProfile : Profile
    {
        public RecurrenceProfile()
        {
            CreateMap<Recurrence, RecurrenceDto>().ReverseMap();
        }
    }
}