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

            while (true)
            {

                Console.WriteLine("Write 1 to show all threads. \n" +
                                  "Write 2 to show all users. \n");

                string x = "";
                x = Console.ReadLine();

                if (x == "1")
                {
                    Console.Clear();

                    while (true)
                    {

                        Console.WriteLine("Write the id of the thread you want to view, with all of it's posts. Write x to go back.");
                        string input = Console.ReadLine();

                        if (input == "x")
                        {
                            Console.Clear();
                            break;
                        }

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

                            }

                            if (threadInput == "2")
                            {

                            }

                            if (threadInput == "3")
                            {

                            }
                        }
                    }
                    continue;
                }

                if (x == "2")
                {
                    continue;
                }

                if (x == "3")
                {
                    continue;
                }
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
            Console.WriteLine($"{thread.Topic}  \n{thread.Text}");
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
