using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Library.Core.Interfaces.Services;

namespace LaBook_Planet.API.Library.Domain.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookService _bookService;

        public BookService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetAll(int pageSize, int pageNumber)
        {
            return await _bookService.GetAll(pageSize, pageNumber);
        }

        public async Task<Result<BookDetailsDto>> GetBookById(string id)
        {
            return await _bookService.GetBookById(id);
        }
    }
}
