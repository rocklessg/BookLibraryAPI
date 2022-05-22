using BookLibrary.Domain.Entities;
using BookLibrary.Infrastructure.Data.DatabaseContexts;
using BookLibrary.Infrastructure.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Services.Implementations
{
    public class BookService : BookQueryCommand<Book>, IBookService
    {
        public BookService(BookLibraryDbContext context) : base(context) { }
    }
}
