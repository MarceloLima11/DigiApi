using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Digi.Infra.Records
{
    public record TamerRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TamerRecord(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}