using LaBook_Planet.API.Library.Domain.Services.Interfaces.Helpers;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LaBook_Planet.API.Controllers
{
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;



        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var result = await _categoryService.GetAllAsync(pageSize, pageNumber);



            if (!result.IsSuccessful)
            {
                return NotFound(ResponseDto<IEnumerable<string>>.Fail(result.Errors));
            }



            return Ok(ResponseDto<PaginatorResponseDto<IEnumerable<GetAllCategoryDto>>>.Success(result.Data!));
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Errors());



            var result = await _categoryService.AddAsync(categoryDto);



            if (!result.IsSuccessful)
                return Conflict(ResponseDto<IEnumerable<string>>.Fail(result.Errors));



            return Ok(ResponseDto<AddCategoryDto>.Success(result.Data!, string.Empty, (int)HttpStatusCode.Created));
        }
    }
}
