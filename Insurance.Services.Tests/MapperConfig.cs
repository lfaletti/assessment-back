using AutoMapper;
using Insurance.IApiProviders.Models;
using Insurance.IServices.ServiceModels;

namespace Insurance.Services.Test
{
    public class MapperConfig
    {
        public static void SetUp()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ClientDTO, ClientServiceModel>().ReverseMap();
                config.CreateMap<ClientServiceModel, ClientDTO>().ReverseMap();

                config.CreateMap<PolicyDTO, PolicyServiceModel>().ReverseMap();
                config.CreateMap<PolicyServiceModel, PolicyDTO>().ReverseMap();
            });
        }
    }
}