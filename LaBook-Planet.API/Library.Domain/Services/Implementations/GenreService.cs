using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.Library.Domain.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepo;

        public GenreService(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public async Task<Result<AddGenreDto>> AddAsync(AddGenreDto genreDto)
        {
            return await _genreRepo.Add(genreDto);
        }

        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllGenreDto>>>> GetAllAsync(int pageSize, int pageNumber)
        {
            return await _genreRepo.GetAll(pageSize, pageNumber);
        }
    }
}
