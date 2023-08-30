using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace Library.Core.Interfaces.Services;

public interface IBookService
{
    public Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetAll(int pageSize, int pageNumber);

    public Task<Result<BookDetailsDto>> GetBookById(string id);
}