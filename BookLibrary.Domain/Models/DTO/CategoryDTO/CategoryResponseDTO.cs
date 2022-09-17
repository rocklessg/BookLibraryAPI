using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Domain.Models.DTO.CategoryDTO
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public IEnumerable<Book> Books { get; set; }
        //[Required]
        //public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
