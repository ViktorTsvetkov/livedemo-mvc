using LiveDemo_MVC.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveDemo_MVC.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
        }

        public BookViewModel(BookModel book)
        {
            if (book != null)
            {
                this.Id = book.Id;
                this.Title = book.Title;
                this.Author = book.Author;
                this.ISBN = book.ISBN;
                this.WebSite = book.WebSite;
                this.Description = book.Description;
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }
    }
}