using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DataAccessLayer.Abstract
{
    public interface IProductDAL:IGenericDAL<Product>
    {
        List<Product> GetProductByCategory();

        List<Product> GetProductByGuest(int id);
    }
}
