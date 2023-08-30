namespace LaBook_Planet.ViewModels
{
    public class IndexViewModel
    {
        public string Search { get; set; } = "";
        public IEnumerable<BookViewModel> BookResults { get; set; }
    }
}
