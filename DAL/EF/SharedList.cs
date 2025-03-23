using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SharedList
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ShoppingList")]
        public int ShoppingListId { get; set; }

        [ForeignKey("User")]
        public int SharedWithUserId { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }
        public virtual User User { get; set; }
    }
}
