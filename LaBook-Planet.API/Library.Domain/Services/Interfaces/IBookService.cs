using BookAPI.DTOs;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace Library.Core.Interfaces.Services;

public interface IBookService
{
    public Task<Book> AddBookAsync(AddBookDto book);
    public Task<IEnumerable<Book>> GetAll();

    public Task<Book> GetBookById(string id);


    public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> SearchBooks(string keyword, int pageSize, int pageNumber);
    public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetPopularBooks(int pageSize, int pageNumber);
    public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetRecentBooks(int pageSize, int pageNumber);


}