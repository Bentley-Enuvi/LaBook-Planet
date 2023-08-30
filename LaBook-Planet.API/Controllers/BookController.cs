using AutoMapper;
using BookAPI.DTOs;
using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using LaBook_Planet.API.LibraryCore.API.Repositories;
using Library.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaBook_Planet.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }


        [Authorize(Roles = "admin")]
        [HttpPost("add-a-book")]
        public IActionResult AddBook([FromBody] AddBookDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.Title == "string" || model.Title == "")
                    return BadRequest("Invalid entry");

                //var Date = DateTime.Parse(model.DatePublished);

                var bookToAdd = new Book
                {
                   
                    Title = model.Title,
                    Author = model.Author,
                    //DatePublished = Date,
                    Language = model.Language,
                    Description = model.Description,
                    NumOfPages = model.NumOfPages,
                    ISBN = model.ISBN,
                };
                if (_bookRepo.AddBook(bookToAdd))
                {
                    return Ok("Book successfully added!");
                }
                return BadRequest("Book not added!");
            }
            return BadRequest(ModelState);

        }


        // Get a single book by ID
        [AllowAnonymous]
        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetBook(string id)
        {
            var book = await _bookRepo.GetBookById(id);

            if (!book.IsSuccessful)
            {
                return BadRequest(ResponseDto<IEnumerable<string>>.Fail(book.Errors));
            }

            return Ok(ResponseDto<BookDetailsDto>.Success(book.Data!));
        }



        //Get all the list of books available
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBooks([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
           var result = await _bookRepo.GetAllBooks(pageSize, pageNumber);
            if (!result.IsSuccessful)
            {
                return BadRequest(ResponseDto<IEnumerable<string>>.Fail(result.Errors));
            }

            return Ok(ResponseDto<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Success(result.Data!));
        }


        [Authorize(Roles = "admin, editor")]
        [Authorize(Policy = "CanEdit")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBook(string id, [FromQuery]UpdateBookDto model)
        {
            var existingBook = await _bookRepo.GetBookById(id);

            if (!existingBook.IsSuccessful)
            {
                return BadRequest("Update failed");
            }

            return Ok($"Book with id: {id} successfully updated");
           
        }


        [Authorize(Roles = "admin")]
        [Authorize(Policy = "CanDelete")]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBook(string id)
        {
            var existingBook = _bookRepo.GetBookById(id);
            if (existingBook != null)
            {
                if (_bookRepo.DeleteBook(existingBook))
                {
                    return Ok("Deleted successfully");
                }

                return BadRequest("Deleted failed");
            }

            return BadRequest($"Delete failed: Could not get forecast with id {id}");

        }
    }
}
