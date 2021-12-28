using AutoMapper;
using MyFinances.API.Dtos;
using MyFinances.Core.Aggregates.HouseholdAggregate;

namespace MyFinances.API.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<AddNewTransactionRequest, Transaction>().ReverseMap();
        }
    }
}
