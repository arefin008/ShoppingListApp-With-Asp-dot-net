using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ShoppingItemService
    {
        public static List<ShoppingItemDTO> Get() 
        {
            var data = DataAccessFactory.ItemData().Read(); 
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ShoppingItem, ShoppingItemDTO>(); 
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ShoppingItemDTO>>(data);
            return mapped;
        }

        public static ShoppingItemDTO Get(int id) 
        {
            var data = DataAccessFactory.ItemData().Read(id); 
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ShoppingItem, ShoppingItemDTO>(); 
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ShoppingItemDTO>(data); 
            return mapped;
        }

        public static bool Create(ShoppingItemDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShoppingItemDTO, ShoppingItem>(); 
            });

            var mapper = new Mapper(config);
            var post = mapper.Map<ShoppingItem>(obj); 

            return DataAccessFactory.ItemData().Create(post); 
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.ItemData(); 
            return repo.Delete(id); 
        }


        public static bool Update(ShoppingItemDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShoppingItemDTO, ShoppingItem>(); 
            });

            var mapper = new Mapper(config);
            var post = mapper.Map<ShoppingItem>(obj); 

            return DataAccessFactory.ItemData().Update(post); 
        }
        public static bool MarkBoughtStatus(int id)
        {
            var item = DataAccessFactory.ItemData().Read(id);
            if (item == null) return false;

            item.IsBought = !item.IsBought;
            return DataAccessFactory.ItemData().Update(item);
        }

        public static List<ShoppingItemDTO> GetByCategory(string category)
        {
            var data = DataAccessFactory.ItemData2().ReadByCategory(category);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ShoppingItem, ShoppingItemDTO>();
            });

            var mapper = new Mapper(cfg);
            return mapper.Map<List<ShoppingItemDTO>>(data);
        }

        public static List<ShoppingItemDTO> GetSortedItems(string sortBy)
        {
            var data = DataAccessFactory.ItemData2().GetSortedItems(sortBy);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ShoppingItem, ShoppingItemDTO>();
            });

            var mapper = new Mapper(cfg);
            return mapper.Map<List<ShoppingItemDTO>>(data);
        }



    }
}
