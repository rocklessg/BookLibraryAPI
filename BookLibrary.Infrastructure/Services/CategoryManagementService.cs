using AutoMapper;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.DTO.CategoryDTO;
using BookLibrary.Domain.Services.InfrastructureServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BookLibrary.Infrastructure.Services
{
    public class CategoryManagementService : ICategoryManagementService
    {
        private readonly ICategoryManagement _categoryManagement;

        public CategoryManagementService(ICategoryManagement categoryManagement)
        {
            _categoryManagement = categoryManagement;
        }

        public async Task<int> AddNewCategoryAsync(CategoryResponseDTO newCategory)
        {
            Category category = new();
            int categoryId;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                category.Name = newCategory.Name;
                category.CreatedAt = DateTime.Now;
                category.LastModifiedAt = DateTime.Now;

                categoryId = await _categoryManagement.AddCategoryAsync(category);

                List<Book> books = new();
                foreach (string name in newCategory.Books.Split(','))
                {
                    Book book = new()
                    {
                        Title = name,
                        CategoryId = categoryId,
                        Author = newCategory.Author,
                        Publisher = newCategory.Publisher,
                        PublishedDate = newCategory.PublishedDate,
                        ISBN = newCategory.ISBN,
                        ImageUrl = newCategory.ImageUrl,
                        Description = newCategory.Description,
                        IsFavorite = newCategory.IsFavorite,
                        CreatedAt = DateTime.Now,
                        LastModifiedAt = DateTime.Now,
                    };
                    books.Add(book);
                }
                await _categoryManagement.AddBooksToCategoryAsync(books);
                scope.Complete();
            }
            return categoryId;
        }
    }
}
