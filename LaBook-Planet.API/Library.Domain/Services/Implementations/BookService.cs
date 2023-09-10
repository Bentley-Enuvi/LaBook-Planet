using AutoMapper;
using BookAPI.DTOs;
using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Library.Core.Interfaces.Services;

namespace LaBook_Planet.API.Library.Domain.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task<Book> AddBookAsync(AddBookDto bookDto)
        {
            var newBook = _mapper.Map<Book>(bookDto);

            var bookAdded = await _bookRepo.AddBookAsync(newBook);

            return bookAdded;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepo.GetAll();
        }

        public async Task<Book> GetBookById(string id)
        {
            return await _bookRepo.GetBookById(id);
        }

        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetPopularBooks(int pageSize, int pageNumber)
        {
            return await _bookRepo.GetPopularBooks(pageSize, pageNumber);
        }

        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetRecentBooks(int pageSize, int pageNumber)
        {
            return await _bookRepo.GetRecentBooks(pageSize, pageNumber);
        }

        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> SearchBooks(string keyword, int pageSize = 10, int pageNumber = 1)
        {
            return await _bookRepo.SearchBooks(keyword, pageSize, pageNumber);
        }
    }
}
