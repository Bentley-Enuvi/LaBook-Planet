using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
//using LaBook_Planet.API.LibraryCore.API.Repositories;
using Library.Core.Interfaces.Services;
using AutoMapper;
using BookAPI.DTOs;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_PlanetApi.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBookRepository _bookRepository;
        private readonly LaBookContextApi _context;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper, IBookRepository bookRepository, LaBookContextApi context)
        {
            _bookRepository = bookRepository;
            _context = context;
            _bookService = bookService;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            await _bookService.AddBookAsync(bookDto);




            return Ok("Book added successfully!");
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _bookService.GetAll();

            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {
            var book = _bookService.GetBookById(id);
            if (book.Id > 0)
            {

                return Ok(book);
            }

            return NotFound($"No result found for record with id: {id}");
        }



        [HttpGet("Search-books")]
        public async Task<IActionResult> SearchBooks(string keyword, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Fail(new[] { "Keyword must not be empty." }));

            var result = await _bookService.SearchBooks(keyword, pageSize, pageNumber);

            if (!result.IsSuccessful)
            {
                return BadRequest(ResponseDto<IEnumerable<string>>.Fail(result.Errors));
            }



            return Ok(ResponseDto<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Success(result.Data!));



        }



        [HttpGet("Get-popular-books")]
        public async Task<IActionResult> GetPopularBooks([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var result = await _bookService.GetPopularBooks(pageSize, pageNumber);



            if (!result.IsSuccessful)
            {
                return BadRequest(ResponseDto<IEnumerable<string>>.Fail(result.Errors));
            }



            return Ok(ResponseDto<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Success(result.Data!));



        }



        [HttpGet("Get-recent-books")]
        public async Task<IActionResult> GetRecentBooks([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var result = await _bookService.GetRecentBooks(pageSize, pageNumber);



            if (!result.IsSuccessful)
            {
                return BadRequest(ResponseDto<IEnumerable<string>>.Fail(result.Errors));
            }



            return Ok(ResponseDto<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Success(result.Data!));
        }


    }
}
