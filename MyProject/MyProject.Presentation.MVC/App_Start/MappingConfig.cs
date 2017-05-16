using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Presentation.MVC.Models;

namespace MyProject.Presentation.MVC.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Product, ProductModel>()
                .ForMember(dest=>dest.ProductCategory,opt=>opt.MapFrom(scr=>scr.ProductCategory.Id));
                config.CreateMap<ProductModel, Product>()
                .ForMember(dest=>dest.ProductCategory,opt=>opt.MapFrom(src=>src.ProductCategory))
              ;
            });
        }
    }
}