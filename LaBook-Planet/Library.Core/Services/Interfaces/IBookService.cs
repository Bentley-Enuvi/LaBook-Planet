using LaBook_Planet.ViewModels;

namespace LaBook_Planet.Library.Core.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAll();
    }
}
