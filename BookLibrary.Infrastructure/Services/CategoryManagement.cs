using AutoMapper;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.DTO.CategoryDTO;
using BookLibrary.Domain.Services.InfrastructureServices;
using BookLibrary.Infrastructure.Data.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BookLibrary.Infrastructure.Services
{
    public class CategoryManagement : ICategoryManagement
    {
        private readonly BookLibraryDbContext _context;
        private readonly IBookLibraryGenericQuery<Category> _bookLibraryGenericQuery;

        public CategoryManagement(BookLibraryDbContext context, IBookLibraryGenericQuery<Category> bookLibraryGenericQuery)
        {
            _context = context;
            _bookLibraryGenericQuery = bookLibraryGenericQuery;
        }

        /// <summary>
        /// Commands
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public async Task AddBooksToCategoryAsync(List<Book> books)
        {
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Commands
        /// </summary>
        /// <param name="catgory"></param>
        /// <returns></returns>
        public async Task<int> AddCategoryAsync(Category catgory)
        {
            await _context.Categories.AddAsync(catgory);
            await _context.SaveChangesAsync();
            return catgory.Id;
        }
    }
}
