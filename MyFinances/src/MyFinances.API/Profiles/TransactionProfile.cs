using AutoMapper;
using MyFinances.API.Dtos;
using MyFinances.Blazor.Shared;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.API.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<AddNewTransactionRequest, Transaction>().ReverseMap();
            CreateMap<GetTransactionsInRangeResponse, Transaction>().ReverseMap();
        }
    }
}
