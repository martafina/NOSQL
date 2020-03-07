using DAL.Enteties;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PostRepository
    {
        IMongoDatabase database;
        IMongoCollection<Post> collection;
        public PostRepository()
        {
            database = ConfigManager.GetDefaultDatabase();
            collection = database.GetCollection<Post>(GetTableName());
        }

        private string GetTableName()
        {
            return "post";
        }

        //work with posts 

        public void Add(Post post) =>
          collection.InsertOne(post);

        public void Add(IEnumerable<Post> posts) =>
            collection.InsertMany(posts);
        
        public void Update(ObjectId id, Post post) =>
            collection.ReplaceOne(p => p.Id == id, post);

        public void UpdatePost(ObjectId postId, string newTxt)
        {
            var filter = Builders<Post>.Filter.Eq("_id", postId);
            var update = Builders<Post>.Update.Set("Text", newTxt);
            collection.UpdateOne(filter, update);
        }

        //  work with likes
        
        public void AddLike(string UserNickname, ObjectId postId)
        {
            var filter = Builders<Post>.Filter.Eq("_id", postId);
            var update = Builders<Post>.Update.Inc("Like", 1);
            collection.UpdateOne(filter, update);
 
            update = Builders<Post>.Update.Push("PersonsWhoLike", UserNickname);
            collection.UpdateOne(filter, update);
        
        }

        
        //work with comments

        public void AddComment(Comment comment, ObjectId postId)
        {
            var filter = Builders<Post>.Filter.Eq("_id", postId);
            var update = Builders<Post>.Update.Push("Comments", comment);
            collection.UpdateOne(filter, update);
        }

        public void DeleteComment(Comment comment, ObjectId postId)
        {
            var filter = Builders<Post>.Filter.Eq("_id", postId);
            var update = Builders<Post>.Update.Pull("Comments", comment);
            collection.UpdateOne(filter, update);
        }
       
        //getters

        public List<string> GetPersonsWhoLiked(ObjectId postId)
        {
            var filter = Builders<Post>.Filter.Eq("_id", postId);
            var people = collection.Find(filter).Project(x => x.Likers).First();
            return people;

        }
    
        
        public int GetLike(ObjectId postId)
        {
            var filter = Builders<Post>.Filter.Eq("_id", postId);
            var like = collection.Find(filter).Project(x => x.Like).First();
            return like;
        }

      
        
        public List<Comment> GetComments(ObjectId postId)
        {
            var filter = Builders<Post>.Filter.Eq("_id", postId);
            var people = collection.Find(filter).Project(x => x.Comments).First();
            return people;
        }
        
      

        public List<Post> GetPosts(ObjectId OwnerId) =>
            collection.Find(p => p.PostOwnerId == OwnerId).ToList();

        public Post GetPost(ObjectId id) =>
          collection.Find(p => p.Id == id).FirstOrDefault();

        //deletes
        public void Delete(Post post) =>
             collection.DeleteOne(p => p.Id == post.Id);

        public void Delete(ObjectId postId) =>
           collection.DeleteOne(p => p.Id == postId);
    }
}
