using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models.DTO.CategoryDTO
{
    public class CategoryRequestDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public IEnumerable<Book> Books { get; set; }
        //[Required]
        //public ICollection<Book> Books { get; set; } = new List<Book>();
        //public string Author { get; set; }
        //public string Publisher { get; set; }
        //public string PublishedDate { get; set; }
        //public string ISBN { get; set; }
        //public string ImageUrl { get; set; }
        //public string Description { get; set; }
        //public bool? IsFavorite { get; set; }
    }
}
