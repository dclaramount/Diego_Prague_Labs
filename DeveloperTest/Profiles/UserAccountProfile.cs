using System;
using AutoMapper;

namespace DeveloperTest.Profiles
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<Entities.UserAccount, Models.UserAccountDto>();
            CreateMap<Models.UserAccountForUpdateDto, Entities.UserAccount>();
            CreateMap<Entities.UserAccount, Models.UserAccountForUpdateDto>();

        }
    }
}

