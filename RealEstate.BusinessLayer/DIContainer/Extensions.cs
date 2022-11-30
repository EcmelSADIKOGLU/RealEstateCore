using Microsoft.Extensions.DependencyInjection;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.BusinessLayer.Concrete;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryMenager>();
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();

            services.AddScoped<IMemberService, MemberMenager>();
            services.AddScoped<IMemberDAL, EFMemberDAL>();

            services.AddScoped<IProductService, ProductMenager>();
            services.AddScoped<IProductDAL, EFProductDAL>();
        }
    }
}
