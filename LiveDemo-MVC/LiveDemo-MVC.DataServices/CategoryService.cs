using LiveDemo_MVC.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveDemo_MVC.DataServices.Models;
using LiveDemo_MVC.Data.Contracts;
using LiveDemo_MVC.Data.Models;
using Bytes2you.Validation;

namespace LiveDemo_MVC.DataServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IEfDbSetWrapper<Category> categorySetWrapper;

        private readonly ILiveDemoEfDbContextSaveChanges dbContext;
        
        public CategoryService(IEfDbSetWrapper<Category> categorySetWrapper, ILiveDemoEfDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(categorySetWrapper, "categorySetWrapper").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.categorySetWrapper = categorySetWrapper;
            this.dbContext = dbContext;
        }
        
        public IEnumerable<CategoryModel> GetAllCategoriesSortedById()
        {
            return this.categorySetWrapper.All.ToList().OrderBy(c => c.Id).AsQueryable().Select(CategoryModel.Create).ToList();
        }

        public IEnumerable<CategoryModel> GetAllCategoriesWithBooksIncluded()
        {
            return this.categorySetWrapper.AllWithInclude(c => c.Books).Select(CategoryModel.Create).ToList();
        }

        public CategoryModel GetById(Guid id)
        {
            return new CategoryModel(this.categorySetWrapper.GetById(id));
        }
    }
}