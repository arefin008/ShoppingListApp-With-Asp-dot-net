using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SharedListRepo : Repo, IRepo<SharedList, int, bool>
    {
        public bool Create(SharedList obj)
        {
            db.SharedLists.Add(obj);
            return db.SaveChanges()>0;

        }

        public bool Delete(int id)
        {
            var sharedList = Read(id);
            if (sharedList != null)
            {
                db.SharedLists.Remove(sharedList);
                return db.SaveChanges() > 0; 
            }
            return false;
        }

        public List<SharedList> Read()
        {
            return db.SharedLists.ToList();
        }

        public SharedList Read(int id)
        {
            return db.SharedLists.Find(id);
        }

        public bool Update(SharedList obj)
        {
            var existingSharedList = Read(obj.Id);
            if (existingSharedList != null)
            {
                db.Entry(existingSharedList).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;

            }
            return false;
        }

        
    }
}
