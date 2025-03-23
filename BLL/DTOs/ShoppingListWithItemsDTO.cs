using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShoppingListWithItemsDTO : ShoppingListDTO
    {
        public decimal TotalPriceEstimate { get; set; }
        public List<ShoppingItemDTO> Items { get; set; }
        public ShoppingListWithItemsDTO()
        {
            Items = new List<ShoppingItemDTO>();
        }
    }
}
