using E_Invoice_API.Core.Interfaces.Repositories;
using E_Invoice_API.Data;
using E_Invoice_API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.Repositories
{
    public class ApplicationUserVoteRepository : GenericRepository<ApplicationUserVote>, IApplicationUserVoteRepository
    {
        public ApplicationUserVoteRepository(ApplicationDbContext context) : base(context) { }
    }
}
