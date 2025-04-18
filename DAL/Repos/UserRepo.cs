﻿using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>, IUserAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Users.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(string id)
        {
            return db.Users.Find(id);
        }

        public bool Register(string username, string password, string email)
        {
            
            var existingUser = db.Users.FirstOrDefault(u => u.Username.Equals(username) || u.Email.Equals(email));
            if (existingUser != null)
            {
                return false; 
            }

            
            var newUser = new User
            {
                Username = username,
                Password = password,
                Email = email
            };

            db.Users.Add(newUser);
            return db.SaveChanges() > 0;
        }

        public User Update(User obj)
        {
            var ex = Read(obj.Username);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
