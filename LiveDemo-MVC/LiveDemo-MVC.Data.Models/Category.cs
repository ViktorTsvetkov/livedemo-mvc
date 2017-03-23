using System;
using System.Collections.Generic;

namespace LiveDemo_MVC.Data.Models
{
    public class Category
    {
        private ICollection<Book> books;

        public Category()
        {
            this.books = new HashSet<Book>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
            }
        }
    }
}