﻿using AutoMapper;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.DTO.BookDTO;
using BookLibrary.Domain.Models.DTO.CategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Helpers
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            //Book
            CreateMap<Book, BookRequestDTO>().ReverseMap();
            CreateMap<Book, BookResponseDTO>().ReverseMap();

            //Category
            CreateMap<Category, CategoryRequestDTO>().ReverseMap();
            CreateMap<Category, CategoryResponseDTO>().ReverseMap();
        }
    }
}
