using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Library.Core.Utilities;
using System.Runtime.InteropServices;

namespace LaBook_Planet.API.LibraryCore.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly LaBookContextApi _context;
        public CategoryRepository(LaBookContextApi context)

        {
            _context = context;
        }



        public async Task<Result<AddCategoryDto>> Add(AddCategoryDto categoryDto)

        {

            var category = new Category
            {
                Name = categoryDto.Name,
            };



            await _context.Categories.AddAsync(category);

            return await _context.SaveChangesAsync() > 0

                ? Result<AddCategoryDto>.Success(categoryDto)

                : Result<AddCategoryDto>.Fail(new[] { "could not save genre" });

        }



        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllCategoryDto>>>> GetAll(int pageSize = 10,

            int pageNumber = 1)

        {

            var categories = _context.Genres

                .OrderByDescending(category => category.CreatedAt)

                .Select(category => new GetAllCategoryDto

                {

                    Id = category.Id,

                    Name = category.Name

                });



            var paginatedGenres = await categories.PaginationAsync(pageSize, pageNumber);



            return Result<PaginatorResponseDto<IEnumerable<GetAllCategoryDto>>>.Success(paginatedGenres);

        }
    }
}
