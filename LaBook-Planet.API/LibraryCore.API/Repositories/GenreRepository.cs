using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Library.Core.Utilities;

namespace LaBook_Planet.API.LibraryCore.API.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LaBookContextApi _context;



        public GenreRepository(LaBookContextApi context)
        {
            _context = context;
        }



        public async Task<Result<AddGenreDto>> Add(AddGenreDto genreDto)
        {
            var genre = new Genre
            {
                CategoryId = genreDto.CategoryId,
                Name = genreDto.Name,
            };



            await _context.Genres.AddAsync(genre);
            return await _context.SaveChangesAsync() > 0
                ? Result<AddGenreDto>.Success(genreDto)
                : Result<AddGenreDto>.Fail(new[] { "could not save genre" });
        }



        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllGenreDto>>>> GetAll(int pageSize = 10,
            int pageNumber = 1)
        {
            var genres = _context.Genres
                .OrderByDescending(genre => genre.CreatedAt)
                .Select(genre => new GetAllGenreDto
                {
                    Id = genre.Id,
                    CategoryId = genre.CategoryId,
                    Name = genre.Name
                });



            var paginatedGenres = await genres.PaginationAsync(pageSize, pageNumber);



            return Result<PaginatorResponseDto<IEnumerable<GetAllGenreDto>>>.Success(paginatedGenres);
        }
    }
}
