using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;

namespace LaBook_Planet.API.Library.Domain.Services.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Result<AddCategoryDto>> Add(AddCategoryDto categoryDto);
        public Task<Result<PaginatorResponseDto<IEnumerable<GetAllCategoryDto>>>> GetAll(int pageSize = 10,
            int pageIndex = 1);
    }
}
