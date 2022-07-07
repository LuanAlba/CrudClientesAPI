using AutoMapper;
using CrudClientAPI.Entities;
using CrudClientAPI.Requests;

namespace CrudClientAPI.Mapper
{
    public class ClientsMapper : Profile
    {
        public ClientsMapper()
        {
            CreateMap<AddClientRequest, Client>();
        }
    }
}