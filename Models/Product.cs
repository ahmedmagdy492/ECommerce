using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string Name { get; set; }
        public double Price { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public string SellerName { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public List<Image> Images { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
