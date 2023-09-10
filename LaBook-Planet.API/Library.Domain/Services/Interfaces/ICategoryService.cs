using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.Library.Domain.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<Result<AddCategoryDto>> AddAsync(AddCategoryDto categoryDto);

        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllCategoryDto>>>> GetAllAsync(int pasgeSize,
            int pageNumber);
    }
}
