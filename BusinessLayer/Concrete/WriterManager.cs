using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public void DeleteAdd(Writer writer)
        {
            _writerdal.Delete(writer);
        }

        public Writer GetByID(int id)
        {
            return _writerdal.Get(x => x.WriterID==id);
        }

        public List<Writer> GetList()
        {
            return _writerdal.List();
        }

        public void UpdateAdd(Writer writer)
        {
            _writerdal.Update(writer);
        }

        public void WriterAdd(Writer writer)
        {
            _writerdal.Insert(writer);
        }
    }
}
