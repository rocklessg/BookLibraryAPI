using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models.DTO.CategoryDTO
{
    public class CategoryResponseDTO : CategoryRequestDTO
    {
        public int Id { get; set; }        
    }
}
