using System;
using System.ComponentModel.DataAnnotations;

namespace Synthetica.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Drug Drug { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}

