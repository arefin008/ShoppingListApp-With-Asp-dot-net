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
    public class SharedListService
    {
        public static List<SharedListDTO> Get() 
        {
            var data = DataAccessFactory.SharedListData().Read();  
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SharedList, SharedListDTO>(); 
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SharedListDTO>>(data);
            return mapped;
        }

        public static SharedListDTO Get(int id) 
        {
            var data = DataAccessFactory.SharedListData().Read(id); 
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SharedList, SharedListDTO>(); 
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SharedListDTO>(data); 
            return mapped;
        }

        public static bool Create(SharedListDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SharedListDTO, SharedList>(); 
            });

            var mapper = new Mapper(config);
            var post = mapper.Map<SharedList>(obj); 

            return DataAccessFactory.SharedListData().Create(post); 
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.SharedListData(); 
            return repo.Delete(id); 
        }


        public static bool Update(SharedListDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SharedListDTO, SharedList>(); 
            });

            var mapper = new Mapper(config);
            var post = mapper.Map<SharedList>(obj); 

            return DataAccessFactory.SharedListData().Update(post); 
        }
    }
}
