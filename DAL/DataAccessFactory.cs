using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<ShoppingItem, int, bool> ItemData()
        {
            return new ShoppingItemRepo();
        }
        public static IShoppingItemRepo ItemData2()
        {
            return new ShoppingItemRepo();
        }
        public static IRepo<ShoppingList, int, bool> ListData()
        {
            return new ShoppingListRepo();
        }
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }
        public static IUserAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<SharedList, int, bool> SharedListData()
        {
            return new SharedListRepo();
        }
    }
}
