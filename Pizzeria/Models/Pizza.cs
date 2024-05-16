﻿namespace pizzeria_project.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public Pizza()
        {

        }

        public Pizza(string name, string description, double price, string image = "/img/pizza-placeholder.png")
        {
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.Price = price;
        }
    }
}
