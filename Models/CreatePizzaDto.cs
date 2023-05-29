namespace PizzaApp.Models
{
    public class CreatePizzaDto
    {
        public int SelectedSize { get; set; }
        public List<int> SelectedToppings { get; set; } = null!;
        public double TotalSum { get; set; } = 0;
        public List<int> SelectedToppingsCount { get; set; } = null!;

    }
}
