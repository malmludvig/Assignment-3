using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ForumWithForumDB;

namespace Forum
{
    class Program
    {
   
        static void Main(string[] args)
        {

            var repo = new SqliteInitialization();
            repo.PrintVersion();

            var postRepo = new SqlitePostRepository();
            var threadRepo = new SqliteThreadRepository();
            var userRepo = new SqliteUserRepository();

            while (true)
            {

                Console.WriteLine("Write 1 to show all threads. \n" +
                                  "Write 2 to show all users. \n");

                string x = "";
                x = Console.ReadLine();

                if (x == "1")
                {
                    Console.Clear();
                    threadRepo.GetThreads();

                    while (true)
                    {
                        PrintThreads(threadRepo);

                        var people = threadRepo.GetThreads();
                        Console.WriteLine("Write the id of the thread you want to view." +
                            "\nWrite c to create a new thread." +
                            "\nWrite x to go back.");

                        string input = Console.ReadLine();

                        if (input == "x")
                        {
                            Console.Clear();
                            break;
                        }

                        if (input == "c")
                        {

                            Console.Clear();

                            Thread newThread = new Thread();
                            Console.WriteLine("Write a topic:");
                            newThread.Topic = Console.ReadLine();

                            Console.WriteLine("Write a text:");
                            newThread.Text = Console.ReadLine();

                            threadRepo.AddThread(newThread);
                            Console.WriteLine("Thread added!");

                            continue;
                        }

                        int threadId = int.Parse(input);
                        ListPostInThread(postRepo, threadId);

                        while (true)
                        {
                            Console.WriteLine("Write 1 to add a post");
                            Console.WriteLine("Write 2 to edit a post");
                            Console.WriteLine("Write 3 to delete a post");
                            Console.WriteLine("Write x to go back.");

                            string threadInput = Console.ReadLine();

                            if (threadInput == "x")
                            {
                                Console.Clear();
                                break;
                            }

                            if (threadInput == "1")
                            {

                                Post newPost = new Post();
                                Console.WriteLine("Write a text:");
                                newPost.Text = Console.ReadLine();

                                Console.WriteLine("Write the owners ID:");
                                newPost.UserId = Console.ReadLine();
                                newPost.ThreadId = threadId.ToString();
                                postRepo.AddPost(newPost);
                                Console.Clear();
                                break;
                            }

                            if (threadInput == "2")
                            {
                                Console.WriteLine("What is the ID of the post you want to edit?");
                                string editPost = Console.ReadLine();
                            }

                            if (threadInput == "3")
                            {
                                Console.WriteLine("What is the ID of the post you want to delete?");
                                string deletePost = Console.ReadLine();
                            }
                        }
                    }
                    continue;
                }

                if (x == "2")
                {

                    Console.Clear();

                    userRepo.GetUsers();
                    PrintUsers(userRepo);
                    continue;
                }
                x = "";
            }
        }

        public class SqliteInitialization
        {
            private const string _connectionString = "Data Source=.\\Forum.db";

            public void PrintVersion()
            {
                using var connection = new SqliteConnection(_connectionString);

                System.Console.WriteLine(connection.ServerVersion);
            }
        }
        public static void ListPostInThread(SqlitePostRepository repository, int threadId)
        {

            Console.WriteLine("Enter a thread ID to view all of the posts in it. ");
            Console.Clear();
            var thread = repository.GetThreadWithId(threadId);
            var posts = repository.GetPostsFromThread(thread);
            Console.WriteLine($"{thread.Topic}  \n{thread.Text}\n");
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.User.FirstName}: {post.Text}");
            }
            Console.WriteLine();
        }

        public static void PrintThreads(SqliteThreadRepository repository)
        {
            var people = repository.GetThreads();
            foreach (var person in people)
            {
                Console.WriteLine("Thread id: " + person.ThreadId);
                Console.WriteLine("Topic: " + person.Topic);
                Console.WriteLine("Text: " + person.Text);
                Console.WriteLine();
            }
        }

        public static void PrintUsers(SqliteUserRepository repository)
        {
            var people = repository.GetUsers();
            foreach (var person in people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }
        }
    }
}

