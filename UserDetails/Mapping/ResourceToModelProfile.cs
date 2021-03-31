using AutoMapper;

using UserDetails.Domain.Models;
using UserDetails.Resources;

namespace UserDetails.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserDetailResource, User>();
            CreateMap<SaveUserAddressDetailResource, UserAddressDetail>();
        }
    }
}
