using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.DTO.CategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Services.InfrastructureServices
{
    public interface ICategoryManagement
    {
        Task AddBooksToCategoryAsync(List<Book> books);
        Task<int> AddCategoryAsync(Category catgory);
    }
}
