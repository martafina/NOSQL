using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Enteties
{
    public class Comment
    {
        [BsonIgnoreIfDefault]
        public ObjectId CommentatorId { get; set; }
        [BsonIgnoreIfNull]
        public string Text { get; set; }
    }
}
