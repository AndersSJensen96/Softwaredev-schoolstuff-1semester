using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaGeddonBlazor.Model
{
	public class Type
	{
		//Prop should have price, but forgot and now I'm too lazy to implement it
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("Type")]
		public string Name { get; set; }
	}
}
