﻿using BookLibrary.Domain.Models.DTO.CategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Services.InfrastructureServices
{
    public interface ICategoryManagementService
    {
        Task<int> AddNewCategoryAsync(CategoryRequestDTO newCategory);
    }
}
