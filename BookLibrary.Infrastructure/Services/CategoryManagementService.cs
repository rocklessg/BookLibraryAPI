﻿using AutoMapper;
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
    public class CategoryManagementService : ICategoryManagementService
    {
        private readonly ICategoryManagement _categoryManagement;

        public CategoryManagementService(ICategoryManagement categoryManagement)
        {
            _categoryManagement = categoryManagement;
        }

        public async Task<int> AddNewCategoryAsync(CategoryRequestDTO newCategory)
        {
            Category category = new();
            int categoryId;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                category.Name = newCategory.Name;
                //category.Books = newCategory.Book;
                //category.CreatedAt = DateTime.Now;
                //category.LastModifiedAt = DateTime.Now;

                categoryId = await _categoryManagement.AddCategoryAsync(category);

                List<Book> books = new();
                foreach (var bookModel in newCategory.Books)  //I think it is better for your request to take list of books instead of splitting by comma.
                {
                    Book book = new()
                    {
                        Title = bookModel.Title,
                        CategoryId = categoryId,
                        Author = bookModel.Author,
                        Publisher = bookModel.Publisher,
                        PublishedDate = bookModel.PublishedDate,
                        ISBN = bookModel.ISBN,
                        ImageUrl = bookModel.ImageUrl,
                        Description = bookModel.Description,
                        IsFavorite = bookModel.IsFavorite,
                        //Author = newCategory.Author,
                        //Publisher = newCategory.Publisher,
                        //PublishedDate = newCategory.PublishedDate,
                        //ISBN = newCategory.ISBN,
                        //ImageUrl = newCategory.ImageUrl,
                        //Description = newCategory.Description,
                        //IsFavorite = newCategory.IsFavorite,
                        CreatedAt = DateTime.Now,
                        LastModifiedAt = DateTime.Now
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
