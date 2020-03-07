using DAL.Enteties;
using DAL.Repository;
using DAL.Services;
using SociaNetwork.HelperWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SociaNetwork.SearchPeople
{
    public partial class PersonInfo : Window
    {
     
        string PersonNickName;
        UserRepository repository;
        PostServices postServices;
        UserServices services;
        User user;
        List<Post> posts;
        bool isAnyPosts = false;
        bool tempLike = false;
        bool tempDislike = false;
        Post currentPost;
        int indexOfPost = 0;
        public PersonInfo(string nickname)
        {
            InitializeComponent();
            PersonNickName = nickname;
            //
            repository = new UserRepository();
            services = new UserServices();
            postServices = new PostServices();
 
            //
            user = new User();
            user = repository.GetUser(PersonNickName);
            UserMail.Content = user.Mail;
            //
            currentPost = new Post();
            posts = new List<Post>();
            posts = postServices.GetPosts(PersonNickName);
            if (posts != null && posts.Count > 0)
            {
                currentPost = posts[indexOfPost];
                Main.Content = currentPost.Text;
                isAnyPosts = true;
            }
            else
            {
                Main.Content = "No posts yet";
                //btnDislike.Visibility = Visibility.Hidden;
                //btnLike.Visibility = Visibility.Hidden;
                //btnComment.Visibility = Visibility.Hidden;

                  
            }            
            //
           if (postServices.CheckIfUserLikePost(services.NickNameRead(), currentPost.Id))
            {
                btnLike.Background = Brushes.Green;
                tempLike = true;
            }
            //
            if(services.CheckAlreadyFollow(services.NickNameRead(), PersonNickName))
            {
                btnFollow.Background = Brushes.Green;
            }
            txtLike.Text = postServices.GetLikes(currentPost.Id).ToString();

           
        }

        private void Follow(object sender, RoutedEventArgs e)
        {
            if (!services.CheckAlreadyFollow(services.NickNameRead(),PersonNickName))
            {
                repository.AddFollowing(services.NickNameRead(), PersonNickName);
                repository.AddFollower(PersonNickName, services.NickNameRead());
                btnFollow.Background = Brushes.Green;
            }
           
        }

        private void Unfollow(object sender, RoutedEventArgs e)
        {
            repository.UnFollow(services.NickNameRead(),PersonNickName);
            Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
            SolidColorBrush brush = new SolidColorBrush(color);
            btnFollow.Background = brush;
        }


        private void Comment(object sender, RoutedEventArgs e)
        {
            if (isAnyPosts)
            {
                AddCommentWindow main = new AddCommentWindow(currentPost.Id)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                main.ShowDialog();
            }
        }
       
        private void Like(object sender, RoutedEventArgs e)
        {
            if(tempLike == false)
            {
                btnLike.Background = Brushes.Green;
                tempLike = true;
                postServices.AddLike(services.NickNameRead(),currentPost.Id);
                txtLike.Text = postServices.GetLikes(currentPost.Id).ToString();
            }
            else
            {
                Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
                SolidColorBrush brush = new SolidColorBrush(color);
                btnLike.Background = brush;
                tempLike = false;
                txtLike.Text = postServices.GetLikes(currentPost.Id).ToString();
            }
           
        }


        private void NextPost(object sender, RoutedEventArgs e)
        {
            if (isAnyPosts)
            {
                indexOfPost++;
                if (indexOfPost < posts.Count)
                {
                    currentPost = posts[indexOfPost];
                    Main.Content = currentPost.Text;
                    if (postServices.CheckIfUserLikePost(services.NickNameRead(), currentPost.Id))
                    {
                        btnLike.Background = Brushes.Green;
                        tempLike = true;
                    }
                    else
                    {
                        Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
                        SolidColorBrush brush = new SolidColorBrush(color);
                        btnLike.Background = brush;
                        tempLike = false;
                    }
                }
                else
                {
                    indexOfPost--;
                    currentPost = posts[indexOfPost];
                    Main.Content = currentPost.Text;

                }
                txtLike.Text = postServices.GetLikes(currentPost.Id).ToString();
            }
          

        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void OFF(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreviusPost(object sender, RoutedEventArgs e)
        {
            if (isAnyPosts)
            {
                if (indexOfPost > 0)
                {
                    indexOfPost--;
                    currentPost = posts[indexOfPost];
                    Main.Content = currentPost.Text;
                   if (postServices.CheckIfUserLikePost(services.NickNameRead(), currentPost.Id))
                    {
                        btnLike.Background = Brushes.Green;
                        tempLike = true;
                    }
                    else
                    {
                        Color color = (Color)ColorConverter.ConvertFromString("#0288d1");
                        SolidColorBrush brush = new SolidColorBrush(color);
                        btnLike.Background = brush;
                        tempLike = false;
                    }
                }
                else
                {
                    currentPost = posts[indexOfPost];
                    Main.Content = currentPost.Text;
                  if (postServices.CheckIfUserLikePost(services.NickNameRead(), currentPost.Id))
                    {
                        btnLike.Background = Brushes.Green;
                        tempLike = true;
                    }
                }
                txtLike.Text = postServices.GetLikes(currentPost.Id).ToString();
            }
          
        }

        private void PersonsWhoLikes(object sender, RoutedEventArgs e)
        {
            ListOfPersonsWindow main = new ListOfPersonsWindow(postServices.GetPersonsWhoLiked(currentPost.Id))
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
        }

        private void PersonsWhoComment(object sender, RoutedEventArgs e)
        {
            ListOfCommentsWindow main = new ListOfCommentsWindow(postServices.GetCommentator(currentPost.Id))
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
        }

         private void ViewFollowing(object sender, RoutedEventArgs e)
        {
           
            ListOfPersonsWindow main = new ListOfPersonsWindow(repository.GetFollowing(user.NickName))
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
        }

        private void ViewFollowers(object sender, RoutedEventArgs e)
        {
            ListOfPersonsWindow main = new ListOfPersonsWindow(repository.GetFollowers(user.NickName))
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            main.ShowDialog();
        }


    }
}
