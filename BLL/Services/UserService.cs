using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static UserDTO Create(UserDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>(); 
            });

            var mapper = new Mapper(config);
            var user = mapper.Map<User>(obj); 

            var createdUser = DataAccessFactory.UserData().Create(user); 

            if (createdUser != null)
            {
                var createdUserDTO = mapper.Map<UserDTO>(createdUser); 
                return createdUserDTO;
            }
            return null;
        }

        public static bool Delete(string id)
        {
            return DataAccessFactory.UserData().Delete(id); 
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read(); 

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>(); 
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data); 
        }

        public static UserDTO Get(string id)
        {
            var data = DataAccessFactory.UserData().Read(id); 

            if (data == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>(); 
            });

            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(data); 
        }

        public static bool Authenticate(string username, string password)
        {
            var data = DataAccessFactory.AuthData().Authenticate(username, password);
            return data;
        }

        public static UserWithListDTO GetWithLists(string id)
        {
            var data = DataAccessFactory.UserData().Read(id);

            if (data == null) return null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserWithListDTO>();
                cfg.CreateMap<ShoppingList, ShoppingListDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<UserWithListDTO>(data);
        }
    }
}
