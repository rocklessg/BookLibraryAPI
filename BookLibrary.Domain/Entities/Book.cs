using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool? IsFavorite { get; set; }

        //Establishing relationship
        public Category Category { get; set; }
    }
}
