using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.Interfaces.Services
{
    public interface IApplicationService
    {
        Task CreateApplication(CreateApplicationRequest request, CancellationToken cancellationToken);
        Task<Application> GetApplication(int id, CancellationToken cancellationToken);
        Task<List<Application>> GetApplications(GetApplicationsRequest request, CancellationToken cancellationToken);
    }
}
