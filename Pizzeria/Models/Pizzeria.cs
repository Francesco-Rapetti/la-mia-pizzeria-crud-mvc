namespace pizzeria_project.Models
{
    public class Pizzeria
    {
        public int PizzeriaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Pizza> Pizzas { get; set; }

        public Pizzeria(string name, string description, string image = "https://static.vecteezy.com/system/resources/previews/002/977/249/original/pizzeria-store-front-illustration-in-flat-style-vector.jpg")
        {
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.Pizzas = new List<Pizza>();
        }

        public void AddPizza(Pizza pizza) => Pizzas.Add(pizza);
        public void RemovePizza(Pizza pizza) => Pizzas.Remove(pizza);
    }
}
