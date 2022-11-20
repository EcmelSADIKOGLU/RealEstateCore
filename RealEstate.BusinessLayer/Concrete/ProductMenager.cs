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
    public class ProductMenager : IProductService
    {
        IProductDAL productDAL;

        public ProductMenager(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }

        public void TDelete(Product entity)
        {
            productDAL.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return productDAL.GetByID(id);
        }

        public List<Product> TGetList()
        {
            return productDAL.GetList();
        }

        public List<Product> TGetProductByCategory()
        {
            return productDAL.GetProductByCategory();
        }

        public void TInsert(Product entity)
        {
            productDAL.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            productDAL.Update(entity);
        }
    }
}
