using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LaBook_Planet.API.Library.Domain.Services.Interfaces.Helpers
{
    public static class ModelStateExtension
    {
        public static IEnumerable<string> Errors(this ModelStateDictionary modelState)
        {
            return modelState.SelectMany(m => m.Value?.Errors.Select(mm => mm.ErrorMessage)!);
        }
    }
}
