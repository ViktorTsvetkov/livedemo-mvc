using LiveDemo_MVC.DataServices.Models;
using System;
using System.Collections.Generic;

namespace LiveDemo_MVC.DataServices.Contracts
{
    public interface IBookService
    {
        BookModel GetById(Guid? id);

        IEnumerable<BookModel> GetBooksByTitleOrAuthor(string searchTerm);
    }
}