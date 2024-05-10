using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AuthenticationApplication.Models
{
    [BsonIgnoreExtraElements]
    public class DbEntity
    {
       
            [BsonRepresentation(BsonType.ObjectId)]
            public string _id { get; set; }

            [BsonElement]
            [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
            public DateTime Created_At { get; set; }

            [BsonElement]
            [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
            public DateTime Modified_At = DateTime.UtcNow;

            public bool Deleted { get; set; }
        
    }
}
