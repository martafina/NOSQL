using DAL.Enteties;
using DAL.Repository;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using MongoDB.Bson;

namespace DAL.Services
{
   
    

    public class UserServices
    {
        UserRepository repository;
        public UserServices()
        {
            repository = new UserRepository();
        }
        

        public bool CheckPassword(string nickname ,string password)
        {
            
            User user = new User();
            user = repository.GetUser(nickname);
            if(user!= null)
            {
                if(user.Password == GetHashStringSHA256(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public string GetHashStringSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            string result = "";
            foreach (byte b in hashPassword)
            {
                result += b.ToString();
            }
            return result;
        }

        public bool CheckUniqueOfNickName(string nickname)
        {
            List<User> users = new List<User>();
            users = repository.GetUsers();
            foreach(var elem in users)
            {
                if(elem.NickName == nickname)
                {
                    return false;
                }
            }
            
            return true;
        }
        
        public void NickNameWrite(string NickName)
        {
            var p = new NickInfo();

            p.Nickname = NickName;
            if (p != null)
            {
                using (FileStream fs = new FileStream("NickInfo.json", FileMode.Create))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(NickInfo));
                    jsonFormatter.WriteObject(fs, p);
                }
            }
            else
            {
                using (FileStream fs = new FileStream("NickInfo.json", FileMode.Create))
                {
                    p = new NickInfo { Nickname = "" };
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(NickInfo));
                    jsonFormatter.WriteObject(fs, p);
                }
            }


        }

        public string NickNameRead()
        {
            var p = new NickInfo();
            using (FileStream fs = new FileStream("NickInfo.json", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(NickInfo));
                if (fs.Length != 0)
                {
                    p = (NickInfo)jsonFormatter.ReadObject(fs);
                }

            }

            return p.Nickname;
        }
        //
        public bool CheckAlreadyFollow(string nickname ,string usernickname)
        {
            User user = new User();
            user = repository.GetUser(nickname);
            if(user!= null && user.Following != null)
            {
                foreach (var el in user.Following)
                {
                    if(el == usernickname)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public bool CheckIsUserInDatabase(string nickname)
        {
            User user = new User();
            user = repository.GetUser(nickname);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        

        public bool UpdatePassword(string oldpasssword,string newpassword)
        {
            if (CheckPassword(NickNameRead(), (oldpasssword))) {
                repository.UpdateField(NickNameRead(), "Password", GetHashStringSHA256(newpassword));
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool UpdateField(string nickname,string fieldToEdit,string fieldValue)
        {
            try
            {
                repository.UpdateField(nickname, fieldToEdit, fieldValue);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

      
        
        public void InsertUser(string usMail , string usNickName , string usPassword)
        {
            User user = new User();
           
            user.Mail = usMail;
            user.NickName = usNickName;
            user.Password = GetHashStringSHA256(usPassword);
            DateTime date1 = new DateTime();
     
            repository.Add(user);
        }
        

        public User GetUser()
        {
            try
            {
                return repository.GetUser(NickNameRead());
            }
            catch
            {
                return new User();
            }
            
        }

        public ObjectId GetUserId()
        {
            try
            {
                return repository.GetUserId(NickNameRead());
            }
            catch
            {
                return new ObjectId();
            }
          
        }

        public User GetUser(string nickname)
        {
            try
            {
                return repository.GetUser(nickname);
            }
            catch
            {
                return new User();
            }

        }

        public User GetUser(ObjectId id)
        {
            try
            {
                return repository.GetUser(id);
            }
            catch
            {
                return new User();
            }

        }
        

        public List<string> GetFollowers()
        {
            List<string> ls = new List<string>();
            try
            {
                ls = repository.GetFollowers(NickNameRead());
                return ls;
            }
            catch
            {
                return ls;
            }
        }

        public List<string> GetFollowing()
        {
            List<string> ls = new List<string>();
            try
            {
                ls = repository.GetFollowing(NickNameRead());
                return ls;
            }
            catch
            {
                return ls;
            }
        }
        
       
    }
}
