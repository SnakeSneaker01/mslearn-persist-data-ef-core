using ContosoPizza.Models;

namespace ContosoPizza.Data {
	public static class DbInitializer {
		public static void Initialize(PizzaContext context) {

			if (context.Pizzas.Any() &&
				context.Toppings.Any() &&
				context.Sauces.Any()) {
				return; // DB has been seeded
			}

			var pepperoniTopping = new Topping {
				Name = "Pepperoni", Calories = 130
			};
			var sausageTopping = new Topping {
				Name = "Sausage", Calories = 100
			};
			var hamTopping = new Topping {
				Name = "Ham", Calories = 70
			};
			var chickenTopping = new Topping {
				Name = "Chicken", Calories = 50
			};
			var pineappleTopping = new Topping {
				Name = "Pineapple", Calories = 75
			};

			var tomatoSauce = new Sauce {
				Name = "Tomato", IsVegan = true
			};
			var alfredoSauce = new Sauce {
				Name = "Alfredo", IsVegan = false
			};

			var pizzas = new Pizza[] {
				new Pizza {
					Name = "Meat Lovers",
						Sauce = tomatoSauce,
						Toppings = new List<Topping> {
							pepperoniTopping,
							sausageTopping,
							hamTopping,
							chickenTopping
						}
				},
				new Pizza {
					Name = "Hawaiian",
						Sauce = tomatoSauce,
						Toppings = new List<Topping> {
							pineappleTopping,
							hamTopping
						}
				},
				new Pizza {
					Name = "Alfredo Chicken",
						Sauce = alfredoSauce,
						Toppings = new List<Topping> {
							chickenTopping
						}
				}
			};

			context.Pizzas.AddRange(pizzas);
			context.SaveChanges();
		}

		public static void Initialize(PersonContext context) {

			context.SaveChanges();

			var persons = new List<Person> {
				new Person {
					Name = "Harry",
						Lastname = "Dirty",
						Zipcode = "38844",
						City = "Berlin",
						color = Person.Color.violett
				},
				new Person {
					Name = "C",
						Lastname = "++",
						Zipcode = "11111",
						City = "IrgendwoInDeutschland",
						color = Person.Color.grün
				},
				new Person {
					Name = "Kaffee",
						Lastname = "MehrKaffee",
						Zipcode = "31415",
						City = "NichtInDeutschland",
						color = Person.Color.blau
				},
			};
			AddContextData(context, persons, false);
			context.SaveChanges();
		}

		public static void RemoveContextData(PersonContext context) {
			foreach (var entity in context.Persons)
				context.Persons.Remove(entity);
		}

		public static void AddContextData(PersonContext context, List<Person> personsToAdd, bool duplicatsAlowed = false) {
			foreach (Person person in personsToAdd) {
				if (duplicatsAlowed ||
					context.Persons.Any(o => o.Name == person.Name &&
						o.Lastname == person.Lastname &&
						o.Zipcode == person.Zipcode &&
						o.City == person.City &&
						o.color == person.color))
					continue;
				context.Persons.Add(person);
			}
			context.SaveChanges();
		}

	}
}