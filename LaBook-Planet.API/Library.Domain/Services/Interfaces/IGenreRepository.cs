using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.Library.Domain.Services.Interfaces
{
    public interface IGenreRepository
    {
        public Task<Result<AddGenreDto>> Add(AddGenreDto genreDto);

        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllGenreDto>>>> GetAll(int pageSize = 10,
            int pageNumber = 1);
    }
}
