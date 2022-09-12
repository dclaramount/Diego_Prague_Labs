using System;
using AutoMapper;

namespace DeveloperTest.Profiles
{
    public class InvoiceProfile :Profile
    {
        public InvoiceProfile() 
        {
            CreateMap<Entities.Invoice, Models.InvoiceDto>();
            CreateMap<Entities.Invoice, Models.InvoiceWithDetailsDto>();
            CreateMap<Entities.Invoice, Models.InvoiceWithUserAccountDto>();
            CreateMap<Entities.Invoice, Models.InvoiceWithDetailsAndUserAccountDto>();
            CreateMap<Entities.Invoice, Models.InvoiceWithDetailsAndUserAccountForUpdateDto>();
            CreateMap<Models.InvoiceWithDetailsAndUserAccountForUpdateDto, Entities.Invoice>();
        }
    }
}

