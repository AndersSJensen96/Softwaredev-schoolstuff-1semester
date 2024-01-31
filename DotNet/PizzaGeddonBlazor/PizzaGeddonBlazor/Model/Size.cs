using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace PizzaGeddonBlazor.Model
{
	public class Size
	{
		//Prop should have price, but forgot and now I'm too lazy to implement it
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Size")]
		public string Name { get; set; }
	}
}
