using E_Invoice_API.Common.Enums;
using E_Invoice_API.Core.DTO.Request;
using E_Invoice_API.Core.Exceptions;
using E_Invoice_API.Core.Helper;
using E_Invoice_API.Core.Interfaces.Repositories;
using E_Invoice_API.Core.Interfaces.Services;
using E_Invoice_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace E_Invoice_API.Core.Services
{
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _FAQRepository;

        public FAQService(IFAQRepository FAQRepository)
        {
            _FAQRepository = FAQRepository;
        }

        public async Task<List<FAQ>> GetFAQs(int? FAQId, CancellationToken cancellationToken)
        {
            Expression<Func<FAQ, bool>> predicate = x =>
                   !FAQId.HasValue || x.Id.Equals(FAQId);

            var result = await _FAQRepository.GetAsync(predicate, cancellationToken);

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ForumThreadWithGivenIdNotFound, $"Forum thread with provided id doesn't exist");
            }

            return result.ToList();
        }

        public async Task CreateFAQ(CreateFAQRequest request, CancellationToken cancellationToken)
        {
            var faqToCreate = new FAQ()
            {
                Question = request.Question,
                Answer = request.Answer
            };

            await _FAQRepository.AddAsync(faqToCreate, cancellationToken);
        }

        public async Task DeleteFAQ(int FAQId, CancellationToken cancellationToken)
        {
            var faqToDelete = await _FAQRepository.GetByIdAsync(FAQId, cancellationToken);

            await _FAQRepository.Delete(faqToDelete, cancellationToken);
        }
    }
}
