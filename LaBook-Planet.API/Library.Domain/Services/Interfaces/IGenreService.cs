using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.Library.Domain.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<Result<AddGenreDto>> AddAsync(AddGenreDto genreDto);

        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllGenreDto>>>> GetAllAsync(int pageSize,
            int pageNumber);
    }
}
