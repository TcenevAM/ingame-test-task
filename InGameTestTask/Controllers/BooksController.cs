using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InGameTestTask.Data;
using InGameTestTask.Dtos.CreateDtos;
using InGameTestTask.Dtos.PatchDtos;
using InGameTestTask.Dtos.ReadDtos;
using InGameTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace InGameTestTask.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateNewBook([FromBody]CreateBookDto bookDto)
        {
            var newBook = _mapper.Map<Book>(bookDto);
            if (newBook.Authors.Any(a => a == null)) return BadRequest();
            if (newBook.Genres.Any(g => g == null)) return BadRequest();
            _repository.CreateNewBook(newBook);
            _repository.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAllBooks()
        {
            return Ok(_mapper.Map<List<ReadBookDto>>(_repository.GetAllBooks()));
        }

        [HttpGet("genres")]
        public ActionResult GetAllGenres()
        {
            return Ok(_mapper.Map<IEnumerable<ReadGenresDto>>(_repository.GetAllGenres()));
        }

        [HttpGet("{id}")]
        public ActionResult GetBook(int id)
        {
            var book = _repository.GetBook(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPatch("{id}")]
        public ActionResult EditBook(int id, PatchBookDto newBook)
        {
            var book = _repository.GetBook(id);
            if (book == null) return BadRequest();

            _mapper.Map(book, newBook);
            
            _repository.SaveChanges();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            if (_repository.DeleteBook(id))
            {
                _repository.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}