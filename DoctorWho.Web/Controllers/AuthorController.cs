using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db.Repositories;
using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Controllers
{
    [Route("api/Author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository ??
                throw new ArgumentNullException(nameof(authorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPut("{authorId}")]
        public async Task<ActionResult> UpdateDoctor(int authorId, [FromBody] AuthorForUpdateDto author)
        {
            if (!await _authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var authorToUpdate = _mapper.Map<AuthorDto>(author);
            authorToUpdate.AuthorId = authorId;
            var authorAfterUpdate = await _authorRepository.UpdateAuthorAsync(_mapper.Map<Author>(authorToUpdate));
            return Ok(_mapper.Map<AuthorDto>(authorAfterUpdate));
        }
    }
}
