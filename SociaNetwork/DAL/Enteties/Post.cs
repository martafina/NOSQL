﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enteties
{
    [BsonIgnoreExtraElements]
    public class Post
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonIgnoreIfDefault]
        public ObjectId PostOwnerId { get; set; }
        [BsonIgnoreIfNull]
        public string Text { get; set; }
        [BsonIgnoreIfNull]
        
        public int Like { get; set; }
        [BsonIgnoreIfNull]
        public List<string> Likers { get; set; } //people who likes this post
        [BsonIgnoreIfNull]
       
        public List<Comment> Comments { get; set; }

    }


}
