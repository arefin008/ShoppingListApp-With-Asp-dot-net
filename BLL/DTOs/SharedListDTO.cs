using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SharedListDTO
    {
            public int Id { get; set; }

            [Required]
            public int ShoppingListId { get; set; }

            [Required]
            public string SharedWithUserId { get; set; }
        }
    }

