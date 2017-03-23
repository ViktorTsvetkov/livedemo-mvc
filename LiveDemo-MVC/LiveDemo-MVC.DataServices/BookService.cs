using Bytes2you.Validation;
using LiveDemo_MVC.Data.Contracts;
using LiveDemo_MVC.Data.Models;
using LiveDemo_MVC.DataServices.Contracts;
using LiveDemo_MVC.DataServices.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LiveDemo_MVC.DataServices
{
    public class BookService : IBookService
    {
        private readonly IEfDbSetWrapper<Book> bookSetWrapper;

        private readonly ILiveDemoEfDbContextSaveChanges dbContext;

        public BookService(IEfDbSetWrapper<Book> bookSetWrapper, ILiveDemoEfDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(bookSetWrapper, "bookSetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.bookSetWrapper = bookSetWrapper;
            this.dbContext = dbContext;
        }
        
        public BookModel GetById(Guid? id)
        {
            BookModel result = null;

            if (id.HasValue)
            {
                Book book = this.bookSetWrapper.GetById(id.Value);
                if (book != null)
                {
                    result = new BookModel(book);
                }
            }

            return result;
        }

        public IEnumerable<BookModel> GetBooksByTitleOrAuthor(string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm) ? this.bookSetWrapper.All.Select(BookModel.Create).ToList()
                : this.bookSetWrapper.All.Where(b =>
                (string.IsNullOrEmpty(b.Title) ? false : b.Title.Contains(searchTerm))
                ||
                (string.IsNullOrEmpty(b.Author) ? false : b.Author.Contains(searchTerm)))
                .Select(BookModel.Create).ToList();
        }
    }
}