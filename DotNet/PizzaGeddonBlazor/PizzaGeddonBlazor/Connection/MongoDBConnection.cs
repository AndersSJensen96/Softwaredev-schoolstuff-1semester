namespace PizzaGeddonBlazor.Connection
{
	using MongoDB.Bson;
	using MongoDB.Driver;
	using MongoDB.Driver.Linq;
	using PizzaGeddonBlazor.Model;

	public class MongoDBConnection
	{
		private string connectionString;
		private MongoClient client;
		private MongoCredential credential;

		/// <summary>
		/// Starts instance of MongoDBConnection with needed parameter <see cref="connectionString"/>
		/// </summary>
		//example string: mongodb://[username:password@]host1[:port1][,...hostN[:portN]][/[defaultauthdb][?options]]
		public MongoDBConnection(string username, string password)
		{
			this.connectionString = $"mongodb://{username}:{password}@localhost:27017/?authSource=admin";
		}

		/// <summary>
		/// connect with connectionstring
		/// </summary>
		public void ConnectToMongo()
		{
			client = new MongoClient(connectionString);

		}
		/// <summary>
		/// connect with mongocredentials
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		public void ConnectToMongo(string username, string password)
		{
			credential = MongoCredential.CreateCredential("admin", username, password);
		}

		public List<string>? ListDatabases()
		{
			List<string> databases = null;
			try
			{
				databases = client.ListDatabaseNames().ToList<string>();
			}catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return databases;
		}

		public List<Pizza> GetAllPizzas()
		{
			var db = client.GetDatabase("PizzaGeddon");
			var collection = db.GetCollection<Pizza>("Pizza");
			var list = collection
				.Find<Pizza>(FilterDefinition<Pizza>.Empty).ToList<Pizza>();

			return list;
		}
		public List<Size> GetAllSizes()
		{
			var db = client.GetDatabase("PizzaGeddon");
			var collection = db.GetCollection<Size>("Sizes");
			var list = collection
				.Find<Size>(FilterDefinition<Size>.Empty).ToList<Size>();
			return list;
		}
		public List<Type> GetAllTypes()
		{
			var db = client.GetDatabase("PizzaGeddon");
			var collection = db.GetCollection<Type>("Types");
			var list = collection
				.Find<Type>(FilterDefinition<Type>.Empty).ToList<Type>();
			return list;
		}
		public List<Topping> GetAllToppings()
		{
			var db = client.GetDatabase("PizzaGeddon");
			var collection = db.GetCollection<Topping>("Toppings");
			var list = collection
				.Find<Topping>(FilterDefinition<Topping>.Empty).ToList<Topping>();
			return list;
		}

		public void CreatePizza(Pizza pizza)
		{
			var db = client.GetDatabase("PizzaGeddon");
			var collection = db.GetCollection<Pizza>("Pizza");
			collection.InsertOne(pizza);
		}
		public bool DeletePizza(string pizzaId)
		{
			var db = client.GetDatabase("PizzaGeddon");
			var collection = db.GetCollection<Pizza>("Pizza");
			var result = collection.DeleteOne(x => x.Id == pizzaId);
			return result.IsAcknowledged;
		}
		public void UpdatePizza(Pizza pizza)
		{
			var db = client.GetDatabase("PizzaGeddon");
			var collection = db.GetCollection<Pizza>("Pizza");
			collection.ReplaceOne(x => x.Id == pizza.Id, pizza);
		}
	}
}
