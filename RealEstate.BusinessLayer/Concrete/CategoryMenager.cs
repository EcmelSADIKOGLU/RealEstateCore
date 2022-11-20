using RealEstate.BusinessLayer.Abstract;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.Concrete
{
    public class CategoryMenager : ICategoryService
    {
        ICategoryDAL _CategoryDAL;

        public CategoryMenager(ICategoryDAL categoryDAL)
        {
            _CategoryDAL = categoryDAL;
        }

        public void TDelete(Category entity)
        {
            _CategoryDAL.Delete(entity);
        }

        public Category TGetByID(int id)
        {
            return _CategoryDAL.GetByID(id);
        }

        public List<Category> TGetList()
        {
            return _CategoryDAL.GetList();
        }

        public void TInsert(Category entity)
        {
            _CategoryDAL.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _CategoryDAL.Update(entity);
        }
    }
}
