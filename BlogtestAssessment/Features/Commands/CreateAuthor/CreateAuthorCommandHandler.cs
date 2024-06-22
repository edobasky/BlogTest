using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using BlogtestAssessment.Utilities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BlogtestAssessment.Features.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public CreateAuthorCommandHandler(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {

            if (request.Email is null || request.Name is null) return false;

            Author authorToCreateMapping = new Author()
            {
                Name = request.Name,
                Email = request.Email,
            };

            bool checkAuthorExist = await _unitofWork.AuthorRepository.CheckAuthorExist(request.Email, false);

            if (!checkAuthorExist)
            {
                _unitofWork.AuthorRepository.CreateAuthor(authorToCreateMapping);
                int successfulCommit = await _unitofWork.SaveAsync();

                return (successfulCommit > 0);
            }

            return false;


        }
    }
}
