using DAL.Enteties;
using DAL.Repository;
using DAL.Services;
using SociaNetwork.HelperWindows;
using SociaNetwork.SearchPeople;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SociaNetwork.ucWindows
{
    public partial class ucNewPost : UserControl
    {
     

        PostRepository postRepository;
        PostServices postServices;
        UserServices services;
        User user;
        List<Post> posts;
        bool isAnyPosts = false;
        bool tempLike = false;
        bool tempDislike = false;
        Post currentPost;
        int indexOfPost = 0;
        public ucNewPost()
        {
            InitializeComponent();

            //

            services = new UserServices();
            postServices = new PostServices();
            postRepository = new PostRepository();
            //
            user = new User();
            user = services.GetUser();

            //
            currentPost = new Post();
            posts = new List<Post>();

            if (posts != null && posts.Count > 0)
            {
                currentPost = posts[indexOfPost];
                Main.Content = currentPost.Text;
                isAnyPosts = true;
            }
            else
            {
                Main.Content = "No new posts";
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
            txtLike.Text = postServices.GetLikes(currentPost.Id).ToString();

        }

        private void Posts(object sender, RoutedEventArgs e)
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

        private void Like(object sender, RoutedEventArgs e)
        {
            if (tempLike == false)
            {
                btnLike.Background = Brushes.Green;
                tempLike = true;
                postRepository.AddLike(services.NickNameRead(), currentPost.Id);
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

        private void Person(object sender, RoutedEventArgs e)
        {
            if (isAnyPosts)
            {
                PersonInfo main = new PersonInfo(services.GetUser(currentPost.PostOwnerId).NickName)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                main.ShowDialog();
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

      
    }
}
