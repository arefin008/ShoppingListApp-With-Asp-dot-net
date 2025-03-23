using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShoppingItemDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        public decimal PriceEstimate { get; set; }

        [Required]
        public bool IsBought { get; set; }

        [Required]
        public int ShoppingListId { get; set; }
        public string Type { get; set; }
        public string Store { get; set; }
    }
}
