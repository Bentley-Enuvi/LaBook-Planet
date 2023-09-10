using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.Library.Domain.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Result<AddCategoryDto>> AddAsync(AddCategoryDto categoryDto)
        {
            return await _categoryRepo.Add(categoryDto);
        }

        public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllCategoryDto>>>> GetAllAsync(int pasgeSize, int pageNumber)
        {
            return await _categoryRepo.GetAll(pasgeSize, pageNumber);
        }
    }
}
