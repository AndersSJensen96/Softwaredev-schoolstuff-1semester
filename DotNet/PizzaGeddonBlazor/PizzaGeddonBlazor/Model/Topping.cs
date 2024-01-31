using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaGeddonBlazor.Model
{
	public class Topping
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Name")]
		public string Name { get; set; }
		[BsonElement("Price")]
		public double Price { get; set; }
		[BsonElement("Diets")]
		public List<Diet> Diets { get; set; } = new List<Diet>();
		[BsonElement("Allergies")]
		public List<Allergy> Allergies { get; set; } = new List<Allergy>();

	}
}
