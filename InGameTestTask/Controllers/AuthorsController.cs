using System.Collections.Generic;
using AutoMapper;
using InGameTestTask.Data;
using InGameTestTask.Dtos.CreateDtos;
using InGameTestTask.Dtos.PatchDtos;
using InGameTestTask.Dtos.ReadDtos;
using InGameTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InGameTestTask.Controllers
{
    [Route("authors")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateAuthor([FromBody]CreateAuthorDto author)
        {
            try
            {
                _repository.CreateAuthor(_mapper.Map<Author>(author));
                _repository.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return Ok(_mapper.Map<List<ReadAuthorDto>>(_repository.GetAllAuthors()));
        }

        [HttpGet("id")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _repository.GetAuthor(id);
            if (author == null) return NotFound();
            return Ok(_mapper.Map<ReadAuthorDto>(author));
        }

        [HttpGet("{name}")]
        public ActionResult<Author> GetAuthorsByName(string name)
        {
            var author = _repository.GetAuthorsByName(name);
            if (author == null) return NotFound();
            return Ok(_mapper.Map<ReadAuthorDto>(author));
        }

        [HttpGet("{id}/books")]
        public ActionResult<IEnumerable<Book>> GetAuthorBooks(int id)
        {
            var author = _repository.GetAuthor(id);
            if (author == null) return NotFound();
            return Ok(_mapper.Map<List<ReadAuthorBooksDto>>(author.Books));
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateAuthorInfo(int id, [FromBody]PatchAuthorDto newAuthorInfo)
        {
            var author = _repository.GetAuthor(id);
            if (author == null) return NotFound();

            _mapper.Map(newAuthorInfo, author);
            
            _repository.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteAuthor(int id)
        {
            var author = _repository.GetAuthor(id);
            if (author == null) return BadRequest();
            _repository.DeleteAuthor(author);
            _repository.SaveChanges();
            return Ok();
        }
    }
}