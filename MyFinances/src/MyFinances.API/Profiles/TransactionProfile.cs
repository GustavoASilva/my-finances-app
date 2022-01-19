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
            CreateMap<CreateTransactionRequest, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionRequest, Transaction>().ReverseMap();
            CreateMap<PatchTransactionRequest, Transaction>().ReverseMap();
            CreateMap<GetTransactionsInRangeResponse, Transaction>().ReverseMap();
        }
    }
}
