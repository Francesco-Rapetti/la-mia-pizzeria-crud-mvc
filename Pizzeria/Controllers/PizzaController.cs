using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizzeria_project.Models;

namespace pizzeria_project.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Seed()
        {
            List<Category> categories = new();
            {
                using PizzaContext db = new();
				db.Categories.RemoveRange(db.Categories);
                db.Categories.Add(new Category("Classica", "primary"));
                db.Categories.Add(new Category("Bianca", "light"));
                db.Categories.Add(new Category("Rossa", "danger"));
                db.Categories.Add(new Category("Vegetariana", "success"));
                db.Categories.Add(new Category("Esotica", "warning"));

                db.SaveChanges();

                categories = db.Categories.ToList();
            }

            {
                using PizzaContext db = new();
                db.Pizzas.RemoveRange(db.Pizzas);
                db.Pizzas.Add(new Pizza("Margherita", "Pizza rossa con mozzarella e pomodoro", 4.99, categories[0].Id, "~/img/margherita.png"));
                db.Pizzas.Add(new Pizza("Diavola", "Pizza rossa con mozzarella, pomodoro e salame piccante", 5.99, categories[2].Id, "~/img/diavola.png"));
                db.Pizzas.Add(new Pizza("Hawaiana", "Pizza bianca con mozzarella, prosciutto e ananas", 6.99, categories[4].Id, "~/img/hawaiana.png"));
                db.Pizzas.Add(new Pizza("Quattro Formaggi", "Pizza bianca con mozzarella, gorgonzola, fior di latte e parmigiano", 7.99, categories[1].Id, "~/img/quattro-formaggi.png"));
                db.Pizzas.Add(new Pizza("Quattro Stagioni", "Pizza bianca con mozzarella, fior di latte, funghi e olive", 8.99, categories[3].Id, "~/img/quattro-stagioni.png"));
                db.Pizzas.Add(new Pizza("Funghi", "Pizza bianca con mozzarella, funghi", 9.99, categories[1].Id, "~/img/funghi.png"));
                db.Pizzas.Add(new Pizza("Capricciosa", "Pizza bianca con mozzarella, carciofi, fior di latte e olive", 10.99, categories[3].Id, "~/img/capricciosa.png"));
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            using PizzaContext db = new();
            List<Pizza> pizzas = db.Pizzas.Include(p => p.Category).ToList();
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
            if (!ModelState.IsValid)
            {
                using PizzaContext db1 = new();
                PizzaFormModel model = new();
                model.Pizza = pizza;
                model.Categories = db1.Categories.ToList();
                return View(model);
            }

            Pizza newPizza = new(pizza.Name, pizza.Description, pizza.Price, pizza.CategoryId);
            using PizzaContext db = new();
            db.Pizzas.Add(newPizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            using PizzaContext db = new();
            PizzaFormModel model = new();
            model.Pizza = new();
            model.Categories = db.Categories.ToList();
            return View(model);
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
            PizzaFormModel model = new();
            model.Pizza = pizza;
            model.Categories = db.Categories.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                using PizzaContext db1 = new();
                PizzaFormModel model = new();
                model.Pizza = pizza;
                model.Categories = db1.Categories.ToList();
                return View(model);
            }
            using PizzaContext db = new();
            db.Pizzas.Update(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
