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
            CreateMap<InvoiceStatusModel, LogInvoiceStatusResponse>()
                .ForMember(dest => dest.InvoiceStatusId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.UserModel.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.UserModel.LastName));
            CreateMap<LogInvoiceStatusChangeRequest, LogInvoiceStatusResponse>()
                .ForMember(dest => dest.InvoiceStatusId,
                    opt => opt.MapFrom(src => src.InvoiceStatusId))
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserModel.Id))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.UserModel.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.UserModel.LastName));
            CreateMap<InvoiceStatusModel, LogInvoiceStatusChangeRequest>()
                .ForMember(dest => dest.InvoiceStatusId,
                    opt => opt.MapFrom(src => src.Id));
            CreateMap<InvoiceStatusModel, MailNotificationRequest>()
                .ForMember(dest => dest.ToEmail,
                    opt => opt.MapFrom(src => src.UserModel.Email))
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.UserModel.FirstName + " " + src.UserModel.LastName))
                .ForMember(dest => dest.CurrentStatus,
                    opt => opt.MapFrom(src => src.Status));
            CreateMap<MailNotificationResponse, AddMailHistoryRequest>();
        }
    }
}
