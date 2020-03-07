using DAL.Enteties;
using DAL.Repository;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PostServices
    {
        PostRepository repository;
        UserRepository userRepository;
        UserServices userServices;
        public PostServices()
        {
            repository = new PostRepository();
            userServices = new UserServices();
            userRepository = new UserRepository();
        }
        

        public void InsertPost(string text)
        {
            Post post = new Post();
            post.Text = text;
            post.PostOwnerId = userRepository.GetUserId(userServices.NickNameRead());
        
            repository.Add(post);
        }
        

        public void EditPost(string newText, ObjectId postId)
        {
            try
            {
                repository.UpdatePost(postId, newText);
            }
            catch
            {

            }

        }
        

        public bool DeletePost(ObjectId postId)
        {
            try
            {
                repository.Delete(postId);
                return true;
            }
            catch
            {
                return false;
            }
        }
        

       //likes
        public bool CheckIfUserLikePost(string UserNickname, ObjectId postId)
        {

            Post post = new Post();
            post = repository.GetPost(postId);
            if(post != null)
            {
                if (post.Likers != null && post.Likers.Count > 0)
                {
                    foreach (var nick in post.Likers)
                    {
                        if (nick == UserNickname)
                        {
                            return true;
                        }
                    }
                }
            }
   


            return false;
        }
        
       

      
        
        public void AddLike(string UserNickname, ObjectId postId)
        {
            try
            {
                repository.AddLike(UserNickname, postId);
            }
            catch
            {

            }

        }
        
        public int GetLikes(ObjectId postID)
        {
            try
            {
                return repository.GetLike(postID);
            }
            catch
            {
                return 0;
            }

        }

        //comments
        public bool AddComment(string text, ObjectId postId)
        {

            Comment comment = new Comment();
            comment.Text = text;
            comment.CommentatorId = userRepository.GetUser(userServices.NickNameRead()).Id;
            try
            {
                repository.AddComment(comment, postId);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteComment(string text, ObjectId postId)
        {

            Comment comment = new Comment();
            comment.Text = text;
            comment.CommentatorId = userRepository.GetUser(userServices.NickNameRead()).Id;
            try
            {
                repository.DeleteComment(comment, postId);
                return true;
            }
            catch
            {
                return false;
            }

        }
       
       

       
        //getters
        public List<Post> GetPosts(string nickname)
        {
            List<Post> posts = new List<Post>();
            try
            {
                posts = repository.GetPosts(userRepository.GetUserId(nickname));
                return posts;
            }
            catch
            {
                return posts;
            }

        }

        public Post GetPost(ObjectId postId)
        {
            Post post = new Post();
            try
            {
                post = repository.GetPost(postId);
                return post;
            }
            catch
            {
                return post;
            }

        }
        
        public List<string> GetCommentator(ObjectId postId)
        {
            List<Comment> comments = new List<Comment>();
            try
            {
                comments = repository.GetComments(postId);
                if(comments != null)
                {
                    List<string> res = new List<string>();
                    foreach(var el in comments)
                    {
                        res.Add(userRepository.GetUser(el.CommentatorId).NickName + "\n" + el.Text);
                       
                    }
                    return res;
                }
            }
            catch
            {
                return new List<string>();
            }
            return new List<string>();
        }

        public List<string> GetPersonsWhoLiked(ObjectId postId)
        {
            List<string> ls = new List<string>();
            try
            {
                ls = repository.GetPersonsWhoLiked(postId);
                return ls;
            }
            catch
            {
                return ls;
            }

        }


    }


}
