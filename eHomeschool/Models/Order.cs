﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }

        
        //Relationships
        public List<OrderItem> OrderItems { get; set; }
    }
}
