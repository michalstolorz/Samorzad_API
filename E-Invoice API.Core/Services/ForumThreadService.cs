using E_Invoice_API.Core.Helper;
using E_Invoice_API.Core.Interfaces.Repositories;
using E_Invoice_API.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.Services
{
    public class ForumThreadService : IForumThreadService
    {
        private readonly IForumThreadRepository _forumThreadRepository;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ForumThreadService(IForumThreadRepository forumThreadRepository,
                                  IUserContextProvider userContextProvider,
                                  IDateTimeProvider dateTimeProvider)
        {
            _forumThreadRepository = forumThreadRepository;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }
    }
}
