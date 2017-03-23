using LiveDemo_MVC.Data.Models;
using LiveDemo_MVC.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveDemo_MVC.DataServices.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAllCategoriesWithBooksIncluded();

        IEnumerable<CategoryModel> GetAllCategoriesSortedById();

        CategoryModel GetById(Guid id);
    }
}