using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Books = new List<Book>();
        }
        public string Name { get; set; }

        // Establishing one to many relationship
        public IEnumerable<Book> Books { get; set; }
    }
}
