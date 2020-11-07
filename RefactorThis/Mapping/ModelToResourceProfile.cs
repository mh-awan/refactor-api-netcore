using AutoMapper;
using RefactorThis.Models;
using RefactorThis.Resources;

namespace RefactorThis.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Product, ProductResource>();
        }
    }
}
