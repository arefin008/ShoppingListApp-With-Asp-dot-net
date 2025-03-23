using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class ShoppingListService
    {
        public static List<ShoppingListDTO> Get()
        {
            var data = DataAccessFactory.ListData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ShoppingList, ShoppingListDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ShoppingListDTO>>(data);
            return mapped;
        }

        public static ShoppingListDTO Get(int id) 
        {
            var data = DataAccessFactory.ListData().Read(id); 
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ShoppingList, ShoppingListDTO>(); 
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ShoppingListDTO>(data); 
            return mapped;
        }

        public static bool Create(ShoppingListDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShoppingListDTO, ShoppingList>(); 
            });

            var mapper = new Mapper(config);
            var list = mapper.Map<ShoppingList>(obj); 

            return DataAccessFactory.ListData().Create(list); 
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.ListData(); 
            return repo.Delete(id); 
        }


        public static bool Update(ShoppingListDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShoppingListDTO, ShoppingList>(); 
            });

            var mapper = new Mapper(config);
            var list = mapper.Map<ShoppingList>(obj); 

            return DataAccessFactory.ListData().Update(list);
        }


        public static ShoppingListWithItemsDTO GetwithItems(int id)
        {
            var data = DataAccessFactory.ListData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ShoppingList, ShoppingListWithItemsDTO>();
                c.CreateMap<ShoppingItem, ShoppingItemDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ShoppingListWithItemsDTO>(data);
            return mapped;
        }
        public static ShoppingListWithItemsDTO TotalPriceEstimation(int id)
        {
            var mapped = GetwithItems(id);
            if (mapped == null)
            {
                return null; 
            }
            mapped.TotalPriceEstimate = mapped.Items.Sum(item => item.PriceEstimate);

            return mapped;
        }




    }
}
