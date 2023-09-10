using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.Library.Domain.Services.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> AddBookAsync(Book book);
        public Task<IEnumerable<Book>> GetAll();

        public Task<Book> GetBookById(string id);

        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> SearchBooks(string keyword, int pageSize = 10, int pageNumber = 1);
        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetRecentBooks(int pageSize = 10, int pageNumber = 1);
        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetPopularBooks(int pageSize = 10, int pageNumber = 1);
    }
}
