using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models.DTO.CategoryDTO
{
    public class CategoryRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Books { get; set; }

    }
}
