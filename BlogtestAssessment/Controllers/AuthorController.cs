using BlogtestAssessment.Models.Dto;
using BlogtestAssessment.Models.Entity;
using BlogtestAssessment.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogtestAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IRepositoryUnitofWork _unitofWork;

        public AuthorController(IRepositoryUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAuthor(AuthorToCreate author)
        {
            Author authorToCreateMapping = new Author()
            {
                Name = author.Name,
                Email = author.Email,
            };

            bool checkAuthorExist = await _unitofWork.AuthorRepository.CheckAuthorExist(author.Email, false);

            if (!checkAuthorExist)
            {
                _unitofWork.AuthorRepository.CreateAuthor(authorToCreateMapping);
                int successfulCommit = await _unitofWork.SaveAsync();

                return Ok(successfulCommit > 0);
            }
            return BadRequest("Author already exist");
            
        }
    }
}
