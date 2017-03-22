using Bytes2you.Validation;
using LiveDemo_MVC.Data.Contracts;
using LiveDemo_MVC.Data.Models;
using LiveDemo_MVC.DataServices.Contracts;
using LiveDemo_MVC.DataServices.Models;
using System;

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
    }
}