﻿using E_Invoice_API.Core.Interfaces.Repositories;
using E_Invoice_API.Data;
using E_Invoice_API.Data.Models;

namespace E_Invoice_API.Core.Repositories
{
    public class ForumThreadRepository : GenericRepository<ForumThread>, IForumThreadRepository
    {
        public ForumThreadRepository(ApplicationDbContext context) : base(context) { }
    }
}
