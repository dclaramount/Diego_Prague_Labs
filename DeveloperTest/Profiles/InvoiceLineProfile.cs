using System;
using AutoMapper;

namespace DeveloperTest.Profiles
{
    public class InvoiceLineProfile : Profile
    {
        public InvoiceLineProfile()
        {
            CreateMap<Entities.InvoiceLine, Models.InvoiceLineDto>();
            CreateMap<Models.InvoiceLineForUpdateDto, Entities.InvoiceLine>();
            CreateMap<Entities.InvoiceLine,Models.InvoiceLineForUpdateDto>();
        }
    }
}

