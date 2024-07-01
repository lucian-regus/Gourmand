using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmand.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public ICollection<Basket> Basket { get; set; }
        public int CategoryID {  get; set; }
        public Category Category { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
