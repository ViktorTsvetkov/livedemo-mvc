using Bytes2you.Validation;
using LiveDemo_MVC.DataServices.Contracts;
using LiveDemo_MVC.DataServices.Models;
using LiveDemo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveDemo_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            Guard.WhenArgument(bookService, "bookService").IsNull().Throw();

            this.bookService = bookService;
        }

        public ActionResult Details(Guid? id)
        {
            BookModel book = this.bookService.GetById(id);

            BookViewModel viewModel = new BookViewModel(book);

            return this.View(viewModel);
        }
    }
}