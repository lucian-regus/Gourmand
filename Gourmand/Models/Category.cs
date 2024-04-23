namespace Gourmand.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
