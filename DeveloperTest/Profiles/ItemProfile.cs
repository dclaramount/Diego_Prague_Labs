using System;
using AutoMapper;

namespace DeveloperTest.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Entities.Item, Models.ItemDto>();
            CreateMap<Models.ItemForUpdateDto, Entities.Item>();
            CreateMap<Entities.Item, Models.ItemForUpdateDto>();
        }
    }
}

