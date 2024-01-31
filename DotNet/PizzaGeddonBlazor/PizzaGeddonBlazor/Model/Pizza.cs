using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaGeddonBlazor.Model
{
	public class Pizza
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Name")]
		public string Name { get; set; }
		[BsonElement("Toppings")]
		public List<Topping> Toppings { get; set; } = new List<Topping>();
		[BsonElement("Type")]
		public Type Type { get; set; }
		[BsonElement("Size")]
		public Size Size { get; set; }
		[BsonElement("Price")]
		public double Price { get; set; }
	}
}
