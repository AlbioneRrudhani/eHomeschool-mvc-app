using System.ComponentModel.DataAnnotations;

namespace eHomeschool.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Course Course { get; set; }
        public int Amount { get; set; } //amount of courses


        public string ShoppingCartId { get; set; }
    }
}
