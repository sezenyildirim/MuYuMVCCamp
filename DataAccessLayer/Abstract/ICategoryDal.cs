using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;


namespace DataAccessLayer.Abstract
{
   public interface ICategoryDal:IRepository<Category>
    {
        //Category için CRUD işlemleri
       /// List<Category> List();
       ///
       /// void Insert(Category p);
       /// void Update(Category p);
       /// void Delete(Category p);
       
    }
}
