using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer writer);
        void DeleteAdd(Writer writer);
        void UpdateAdd(Writer writer);
        Writer GetByID(int id);
    }
}
