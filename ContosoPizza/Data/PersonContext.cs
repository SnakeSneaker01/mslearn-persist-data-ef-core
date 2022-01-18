using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;

public class PersonContext : DbContext {
	public PersonContext(DbContextOptions<PersonContext> options) : base(options) {}

	public DbSet<Person> Persons => Set<Person>();
}