using AutoMapper;
using MyFinances.API.Dtos;
using MyFinances.Blazor.Shared.Transaction;
using MyFinances.Core.TransactionAggregate;

namespace MyFinances.API.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionRequest, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionRequest, Transaction>().ReverseMap();
            CreateMap<PatchTransactionRequest, Transaction>().ReverseMap();
            CreateMap<TransactionDto, Transaction>().ReverseMap();
        }
    }
}
