using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserWithListDTO : UserDTO
    {
        public List<ShoppingListDTO> ShoppingLists { get; set; }
        public UserWithListDTO() 
        {
            ShoppingLists = new List<ShoppingListDTO>();
        }
    }
}
