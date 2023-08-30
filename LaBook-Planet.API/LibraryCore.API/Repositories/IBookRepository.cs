using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.LibraryCore.API.Repositories
{
    public interface IBookRepository
    {
        Task<Result<BookDetailsDto>> GetBookById(string id);
        bool AddBook(Book book);
        bool DeleteBook(Book book);
        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetAllBooks(int pageSize, int pageNumber);
        bool GetBook(Book name);
        Task<Result<BookDetailsDto>> UpdateBook(string id, BookDetailsDto updatedBook);
        bool DeleteBook(object existingBookc);
        //bool DeleteBook(Task<Result<BookDetailsDto>> existingBook);
    }
}

