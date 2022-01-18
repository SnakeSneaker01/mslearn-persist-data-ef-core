namespace ContosoPizza.Data;

public static class Extensions {
	public static void CreateDbIfNotExists(this IHost host) {
		{
			using(var scope = host.Services.CreateScope()) {
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<PersonContext>();
				
				if (context.Database.EnsureCreated()) {
					DbInitializer.Initialize(context);
				}
			}
		}
	}
	public static void AddData(this IHost host, List<Person> personsToAdd) {
		using(var scope = host.Services.CreateScope()) {
			var services = scope.ServiceProvider;
			var context = services.GetRequiredService<PersonContext>();
			DbInitializer.AddContextData(context, personsToAdd);
		}
	}
}