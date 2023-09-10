using LaBook_Planet.API.Library.Domain.Services.Interfaces.Helpers;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Policy;

namespace LaBook_Planet.API.Controllers
{
    [Route("genres")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var result = await _genreService.GetAllAsync(pageSize, pageNumber);



            if (!result.IsSuccessful)
            {
                return NotFound(ResponseDto<IEnumerable<string>>.Fail(result.Errors));
            }



            return Ok(ResponseDto<PaginatorResponseDto<IEnumerable<GetAllGenreDto>>>.Success(result.Data!));
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGenreDto genreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Errors());
            var result = await _genreService.AddAsync(genreDto);



            if (!result.IsSuccessful)
                return Conflict(ResponseDto<IEnumerable<string>>.Fail(result.Errors));



            return Ok(ResponseDto<AddGenreDto>.Success(result.Data!, string.Empty, (int)HttpStatusCode.Created));
        }

    }
}
