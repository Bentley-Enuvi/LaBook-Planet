using LaBook_Planet.API.Library.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.DTOs
{
    public class AddBookDto
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "";
        public string Language { get; set; } = "";
        public string ISBN { get; set; } = "";
        public DateTime DatePublished { get; set; }
        public int NumOfPages { get; set; }
    
    }
}
