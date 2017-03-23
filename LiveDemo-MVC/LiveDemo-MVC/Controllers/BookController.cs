using Bytes2you.Validation;
using LiveDemo_MVC.DataServices.Contracts;
using LiveDemo_MVC.DataServices.Models;
using LiveDemo_MVC.Infrastructure;
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
        private readonly ICategoryService categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            Guard.WhenArgument(bookService, "bookService").IsNull().Throw();
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        public ActionResult Details(Guid? id)
        {
            BookModel book = this.bookService.GetById(id);

            BookViewModel viewModel = new BookViewModel(book);

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult All()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AllBooks()
        {
            var allCategoryViewModels = this.categoryService.GetAllCategoriesWithBooksIncluded()
                                            .Select(c => new CategoryViewModel(c)).ToList();

            return this.PartialView("_AllBooksPartial", allCategoryViewModels);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult FilteredBooks(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return this.AllBooks();
            }
            else
            {
                var filteredBooks = this.bookService.GetBooksByTitleOrAuthor(searchTerm).Select(b => new BookViewModel(b)).ToList();

                return this.PartialView("_FilteredBooksPartial", filteredBooks);
            }
        }
    }
}