﻿using AutoMapper;
using MyFinances.Blazor.Shared.Origins;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.API.Profiles
{
    public class OriginProfile : Profile
    {
        public OriginProfile()
        {
            CreateMap<Origin, CreateOriginRequest>().ReverseMap();
            CreateMap<Origin, GetOriginsResponse>().ReverseMap();
        }
    }
}