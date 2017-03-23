using LiveDemo_MVC.DataServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace LiveDemo_MVC.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
        }

        public CategoryViewModel(CategoryModel category)
        {
            this.Name = category.Name;
            this.Books = category.Books.Select(b => new BookViewModel(b)).ToList();
        }

        public string Name { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }
    }
}