using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ShoppingItemRepo : Repo, IShoppingItemRepo, IRepo<ShoppingItem, int, bool>
    {
        public bool Create(ShoppingItem obj)
        {
            db.ShoppingItems.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var Item = Read(id);
            if(Item != null)
            {
                db.ShoppingItems.Remove(Item);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<ShoppingItem> Read()
        {
            return db.ShoppingItems.ToList();
        }

        public ShoppingItem Read(int id)
        {
            return db.ShoppingItems.Find(id);
        }

        public bool Update(ShoppingItem obj)
        {
            var existingItem = Read(obj.Id);
            if(existingItem != null)
            {
                db.Entry(existingItem).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<ShoppingItem> ReadByCategory(string category)
        {
            var data = (from u in db.ShoppingItems
                         where u.Category.Contains(category)
                         select u).ToList();
            return data;
        }

        public List<ShoppingItem> GetSortedItems(string sortBy)
        {
            if (sortBy == "Type")
            {
                return db.ShoppingItems.OrderBy(item => item.Type).ToList();
            }
            else if (sortBy == "Store")
            {
                return db.ShoppingItems.OrderBy(item => item.Store).ToList();
            }
            else
            {
                
                return db.ShoppingItems.ToList();
            }
        }
    }
}

