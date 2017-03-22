using LiveDemo_MVC.DataServices.Models;
using System;

namespace LiveDemo_MVC.DataServices.Contracts
{
    public interface IBookService
    {
        BookModel GetById(Guid? id);
    }
}