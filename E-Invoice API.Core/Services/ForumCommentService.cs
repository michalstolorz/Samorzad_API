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
    public class ForumCommentService : IForumCommentService
    {
        private readonly IForumCommentRepository _forumCommentRepository;
        private readonly IUserContextProvider _userContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ForumCommentService(IForumCommentRepository forumCommentRepository,
                                  IUserContextProvider userContextProvider,
                                  IDateTimeProvider dateTimeProvider)
        {
            _forumCommentRepository = forumCommentRepository;
            _userContextProvider = userContextProvider;
            _dateTimeProvider = dateTimeProvider;
        }


    }
}
