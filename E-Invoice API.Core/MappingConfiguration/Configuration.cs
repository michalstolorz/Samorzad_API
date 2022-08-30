using AutoMapper;
using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Core.DTO.Response;
using E_Invoice_API.Core.Models;
using E_Invoice_API.Data.Models;

namespace E_Invoice_API.Core.MappingConfiguration
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<User, UserModel>();
            CreateMap<User, LoginResponse>();
            CreateMap<RegisterRequest, User>()
               .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.Email));
            CreateMap<MailNotificationResponse, AddMailHistoryRequest>();
        }
    }
}
