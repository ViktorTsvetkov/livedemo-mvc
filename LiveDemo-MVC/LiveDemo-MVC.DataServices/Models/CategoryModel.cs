using LiveDemo_MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LiveDemo_MVC.DataServices.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
        }

        public CategoryModel(Category category)
        {
            if (category != null)
            {
                this.Id = category.Id;
                this.Name = category.Name;
                this.Books = category.Books.Select(b => new BookModel(b)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BookModel> Books { get; set; }

        public static Expression<Func<Category, CategoryModel>> Create
        {
            get
            {
                return c => new CategoryModel()
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Books = c.Books.AsQueryable().Select(BookModel.Create).ToList()
                            };
            }
        }
    }
}