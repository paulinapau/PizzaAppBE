namespace PizzaApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public Size Size { get; set; } = null!;
        //public List<Topping> Toppings { get; set; } = new List<Topping>();
        public string ToppingsNames { get; set; } = null!;
        public double TotalSum { get; set; } = 0;
    }
}
