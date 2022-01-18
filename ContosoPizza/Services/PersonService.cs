using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PersonService {
	private readonly PersonContext _context;

	public PersonService(PersonContext context) {
		_context = context;
	}

	public IEnumerable<Person> GetAll() {
		return _context.Persons
			.AsNoTracking()
			.ToList();
	}

	public IEnumerable<Person> GetByColor(Person.Color color) {
		return _context.Persons
			.AsNoTracking()
			.ToList().FindAll(p => p.color == color);
	}

	public Person? Get(int id) {
		return _context.Persons
			.AsNoTracking()
			.SingleOrDefault(p => p.Id == id);
	}

	public Person Create(Person newPerson) {
		_context.Persons.Add(newPerson);
		_context.SaveChanges();

		return newPerson;
	}

	public void UpdateColor(int personId, Person.Color color) {
		var personToUpdate = _context.Persons.Find(personId);

		if (personToUpdate is null) {
			throw new NullReferenceException("Person does not exist.");
		}
		personToUpdate.color = color;

		_context.SaveChanges();
	}

	public void DeleteById(int id) {
		var personToDelete = _context.Persons.Find(id);
		if (personToDelete is not null) {
			_context.Persons.Remove(personToDelete);
			_context.SaveChanges();
		}
	}

}