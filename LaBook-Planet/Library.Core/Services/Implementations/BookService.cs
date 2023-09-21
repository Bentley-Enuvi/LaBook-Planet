using LaBook_Planet.Library.Core.Services.Interfaces;
using LaBook_Planet.Models.Enums;
using LaBook_Planet.ViewModels;

namespace LaBook_Planet.Library.Core.Services.Implementations
{
    public class BookService : BaseService, IBookService
    {
        public BookService(HttpClient client, IConfiguration config) : base(client, config)
        {

        }



        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var address = "/books";
            var methodType = ApiVerbs.GET.ToString();



            var result = await MakeRequest<IEnumerable<BookViewModel>, string>(address, methodType, "", "");



            if (result != null)
                return result;



            return new List<BookViewModel>();
        }
    }
}
