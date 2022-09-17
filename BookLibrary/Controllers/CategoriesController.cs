using AutoMapper;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.DTO.BookDTO;
using BookLibrary.Domain.Models.DTO.CategoryDTO;
using BookLibrary.Domain.Models.Pagination;
using BookLibrary.Domain.Services.InfrastructureServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IBookLibraryGenericQuery<Category> _categoryQueryCommand;
        private readonly ICategoryManagementService _categoryManagementService;
        private readonly IBookLibraryGenericQuery<Book> _bookQueryCommand;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        public CategoriesController(IBookLibraryGenericQuery<Category> categoryQueryCommand, ICategoryManagementService categoryManagementService, ILogger<CategoriesController> logger, IMapper mapper, IBookLibraryGenericQuery<Book> bookQueryCommand)
        {
            _categoryQueryCommand = categoryQueryCommand;
            _categoryManagementService = categoryManagementService;
            _logger = logger;
            _mapper = mapper;
            _bookQueryCommand = bookQueryCommand;
        }

        /// <summary>
        /// Get all Categories.
        /// </summary>
        ///<response code="200">Returned all cagtegories or empty array</response>
        ///
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] RequestParams requestParams)
        {
            var categories = await _categoryQueryCommand.GetAllAsync(requestParams);
            var categoriesList = _mapper.Map<IList<CategoryResponseDTO>>(categories);
            foreach(var category in categoriesList)
            {
                Func<Book, bool> bookCategories = x => x.CategoryId == category.Id;
                category.Books = await _bookQueryCommand.GetAllAsyncWithoutParams(bookCategories);

            }
            return Ok(categoriesList);
        }

        /// <summary>
        /// Get Category by id
        /// </summary>
        ///<response code="200">Returned single category or empty array</response>
        ///
        [HttpGet("{id:int}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            if (id != 0)
            {
                var category = await _categoryQueryCommand.GetByIdAsync(id);
                if (category == null)
                {
                    _logger.LogError($"Invalid GET attemp in {nameof(GetCategoryAsync)}");
                    return NotFound();
                }
                Func<Book, bool> bookCategories = x => x.CategoryId == category.Id;
                category.Books = await _bookQueryCommand.GetAllAsyncWithoutParams(bookCategories);
                var results = _mapper.Map<CategoryResponseDTO>(category);
                return Ok(results);
            }
            return BadRequest();
        }

        /// <summary>
        /// Add a new Category.
        /// </summary>
        ///<response code="201">Returned for a category added successfuly</response>
        ///
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> AddNewCategoryAsync([FromBody] CategoryRequestDTO categoryDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError($"Invalid POST attemp in {nameof(AddNewCategoryAsync)}");
        //        return BadRequest(ModelState);
        //    }

        //    var category = _mapper.Map<Category>(categoryDto);
        //    await _categoryQueryCommand.AddAsync(category);
        //    //await _categoryManagementService.AddNewCategoryAsync(categoryDto);

        //    return CreatedAtRoute("GetCategoryAsync", new { id = category.Id }, category);
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryRequestDTO payload)
        {
            payload.Id = await _categoryManagementService.AddNewCategoryAsync(payload);
            return CreatedAtRoute("GetCategoryAsync", new { id = payload.Id }, payload);
        }

        /// <summary>
        /// Edit an existing category.
        /// </summary>
        ///<response code="204">Returned when category is edited successfully</response>
        ///<response code="400">Returned when id in request route doesnt match request body</response>
        ///<response code="404">Returned when category does not exist</response>
        ///
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditCategoryAsync(int id, [FromBody] CategoryRequestDTO categoryDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(EditCategoryAsync)}");
                return BadRequest(ModelState);
            }

            var category = await _categoryQueryCommand.GetByIdAsync(id);
            if (category == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(EditCategoryAsync)}");
                return BadRequest(ModelState);
            }

            _mapper.Map(categoryDto, category);
            await _categoryQueryCommand.UpdateAsync(category);
            return NoContent();
        }

        /// <summary>
        /// Delete an existing category.
        /// </summary>
        ///<response code="204">Returned when category is deleted successfully</response>
        ///<response code="404">Returned when category is not found</response>
        ///
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategoryAsync)}");
                return NotFound();
            }

            var category = await _categoryQueryCommand.GetByIdAsync(id);
            if (category == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategoryAsync)}");
                return NotFound("Invalid Data");
            }
            await _categoryQueryCommand.DeleteAsync(id);
            return NoContent();
        }
    }
}
