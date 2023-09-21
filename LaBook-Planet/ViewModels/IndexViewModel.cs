namespace LaBook_Planet.ViewModels
{
    public class IndexViewModel
    {
        public string Search { get; set; } = "";
        public IEnumerable<BookViewModel> BookDetails { get; set; } = new List<BookViewModel>();
    }
}
