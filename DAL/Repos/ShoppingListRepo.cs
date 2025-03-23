using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ShoppingListRepo : Repo, IRepo<ShoppingList, int, bool>

    {
        public bool Create(ShoppingList obj)
        {
            db.ShoppingLists.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var list = Read(id);
            if (list !=null)
            {
                db.ShoppingLists.Remove(list);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<ShoppingList> Read()
        {
           return db.ShoppingLists.ToList();   
        }

        public ShoppingList Read(int id)
        {
            return db.ShoppingLists.Find(id);
        }

        public bool Update(ShoppingList obj)
        {
            var existingList = Read(obj.Id);
            if (existingList != null)
            {
                db.Entry(existingList).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false ;

        }
    }
}
