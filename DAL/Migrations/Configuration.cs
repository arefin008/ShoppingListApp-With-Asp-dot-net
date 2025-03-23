namespace DAL.Migrations
{
    using DAL.EF;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.ShoppingListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.ShoppingListContext context)
        {
           
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        context.Users.AddOrUpdate(
        //            new User
        //            {
        //                Username = "User-" + i,
        //                Password = Guid.NewGuid().ToString().Substring(0, 12),
        //                Email = $"user{i}@example.com"
        //            }
        //        );
        //    }

        //    context.SaveChanges();

           
        //    Random random = new Random();
        //    var shoppingLists = new List<ShoppingList>();
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        var shoppingList = new ShoppingList
        //        {
        //            Name = "ShoppingList-" + i,
        //            CreatedAt = DateTime.Now,
        //            UserId = random.Next(1, 11) 
        //        };
        //        shoppingLists.Add(shoppingList);
        //        context.ShoppingLists.AddOrUpdate(shoppingList);
        //    }

        //    context.SaveChanges();

            
        //    for (int i = 1; i <= 50; i++)
        //    {
        //        context.ShoppingItems.AddOrUpdate(
        //            new ShoppingItem
        //            {
        //                Name = "Item-" + i,
        //                Quantity = random.Next(1, 5),
        //                Category = "Category-" + random.Next(1, 4),
        //                PriceEstimate = random.Next(10, 100),
        //                IsBought = false,
        //                Type = "Type-" + i,
        //                Store = "Store-" + i,
        //                ShoppingListId = shoppingLists[random.Next(shoppingLists.Count)].Id
        //            }
        //        );
        //    }

        //    context.SaveChanges();

        //    for (int i = 1; i <= 5; i++)
        //    {
        //        context.SharedLists.AddOrUpdate(
        //            new SharedList
        //            {
        //                ShoppingListId = shoppingLists[random.Next(shoppingLists.Count)].Id, 
        //                SharedWithUserId = random.Next(1, 11) 
        //            }
        //        );
        //    }

        //    context.SaveChanges();
        }

    }
}
