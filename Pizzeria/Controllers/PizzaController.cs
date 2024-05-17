using Microsoft.AspNetCore.Mvc;
using pizzeria_project.Models;

namespace pizzeria_project.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using PizzaContext db = new();
            if(!db.Pizzas.Any())
            {
                db.Pizzas.Add(new Pizza("Margherita", "Pizza rossa con mozzarella", 4.99, "~/img/margherita.png"));
                db.Pizzas.Add(new Pizza("Diavola", "Pizza rossa con mozzarella e salame piccante", 5.99, "~/img/diavola.png"));
                db.Pizzas.Add(new Pizza("Hawaiana", "Pizza bianca con mozzarella, prosciutto e ananas", 6.99, "~/img/hawaiana.png"));
                db.Pizzas.Add(new Pizza("Quattro Formaggi", "Pizza bianca con mozzarella, gorgonzola, fior di latte e parmigiano", 7.99, "~/img/quattro-formaggi.png"));
                db.Pizzas.Add(new Pizza("Quattro Stagioni", "Pizza bianca con mozzarella, fior di latte, funghi e olive", 8.99, "~/img/quattro-stagioni.png"));
                db.Pizzas.Add(new Pizza("Funghi", "Pizza bianca con mozzarella, funghi", 9.99, "~/img/funghi.png"));
                db.Pizzas.Add(new Pizza("Capricciosa", "Pizza bianca con mozzarella, carciofi, fior di latte e olive", 10.99, "~/img/capricciosa.png"));
                db.SaveChanges();
            }
            List<Pizza> pizzas = [.. db.Pizzas];
            return View(pizzas);
        }

        public IActionResult Show(int id)
        {
			using PizzaContext db = new();
			Pizza? pizza = db.Pizzas.Find(id);
			return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            pizza.Price = double.TryParse(pizza.Price.ToString(), out double price) ? price : 0;
            
            if (!ModelState.IsValid)
            {
                return View("Create", pizza);
            }

            Pizza newPizza = new(pizza.Name, pizza.Description, pizza.Price);
            using PizzaContext db = new();
            db.Pizzas.Add(newPizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            using PizzaContext db = new();
            Pizza? pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }
            db.Pizzas.Remove(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            using PizzaContext db = new();
            Pizza? pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pizza pizza)
        {
            pizza.Price = double.TryParse(pizza.Price.ToString(), out double price) ? price : 0;
            if (!ModelState.IsValid)
            {
                return View("Edit", pizza);
            }
            //Pizza newPizza = new(pizza.Name, pizza.Description, pizza.Price);
            using PizzaContext db = new();
            db.Pizzas.Update(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
