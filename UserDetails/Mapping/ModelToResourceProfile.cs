using AutoMapper;
using UserDetails.Domain.Models;
using UserDetails.Resources;

namespace UserDetails.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        
            public ModelToResourceProfile()
            {
                CreateMap<User, UserDetailResource>();
            CreateMap<UserAddressDetail, UserDetailAddressResource>();
            }
        }
    }

