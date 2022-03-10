using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager :ICategoryService
        //:ICategoryService
    {

        // ICategoryDal _categorydal;
        GenericRepository<Category> repo = new GenericRepository<Category>();

        //public CategoryManager(ICategoryDal categorydal)
        //{
        //    _categorydal = categorydal;
        //}
        
        /*_categorydal'a atama yapmamız gerekiyor. 
         * Bunun için constructor kullanırız.
         */

        //GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
       
            repo.Insert(p);
        }

        public List<Category> GetList()
        {
            return repo.List();
        }

        public void AddCategory(Category category)
        {
            repo.Insert(category);
        }
       
        public Category GetByID(int id)
        {
            return repo.Get(x => x.CategoryID == id);
        }

        public void CategoryDelete(Category category)
        {
            repo.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            repo.Update(category);
        }
    }
}
