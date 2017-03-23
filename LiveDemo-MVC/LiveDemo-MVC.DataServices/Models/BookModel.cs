using LiveDemo_MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiveDemo_MVC.DataServices.Models
{
    public class BookModel
    {
        public BookModel()
        {
        }

        public BookModel(Book book)
        {
            if (book != null)
            {
                this.Id = book.Id;
                this.Title = book.Title;
                this.Author = book.Author;
                this.ISBN = book.ISBN;
                this.WebSite = book.WebSite;
                this.Description = book.Description;
                if (book.Category != null)
                {
                    this.CategoryId = book.Category.Id;
                }
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public CategoryModel Category { get; set; }

        public Guid CategoryId { get; set; }

        public static Expression<Func<Book, BookModel>> Create
        {
            get
            {
                return book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    WebSite = book.WebSite,
                    Description = book.Description
                };
            }
        }
    }
}
