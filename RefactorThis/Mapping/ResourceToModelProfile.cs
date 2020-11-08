using AutoMapper;
using RefactorThis.Models;
using RefactorThis.Resources;

namespace RefactorThis.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveProductOptionResource, ProductOption>();
        }
    }
}
