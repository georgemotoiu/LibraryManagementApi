using LibraryManagement.Application.Contracts.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Authors.Queries.GetMostBorrowedAuthors
{
    public class GetMostBorrowedAuthorsQueryHandler : IRequestHandler<GetMostBorrowedAuthorsQuery, GetMostBorrowedAuthorsResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<GetMostBorrowedAuthorsQueryHandler> _logger;

        public GetMostBorrowedAuthorsQueryHandler(IAuthorRepository authorRepository, ILogger<GetMostBorrowedAuthorsQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<GetMostBorrowedAuthorsResponse> Handle(GetMostBorrowedAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Retrieving the top 3 most borrowed authors.");
                var authors = await _authorRepository.GetMostBorrowedAuthorsAsync();
                var getTopBorrowedAuthors = new GetMostBorrowedAuthorsResponse
                {
                    Authors = authors,
                    Success = true
                };

                return getTopBorrowedAuthors;
            }
            catch (Exception e)
            {
                var message = $"Failed to retrieve students -- {e.Message}";
                _logger.LogError(message);

                return new GetMostBorrowedAuthorsResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
