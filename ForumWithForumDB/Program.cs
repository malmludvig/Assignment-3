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
        public class User
        {
            private int _id = -1;

            public int Id
            {
                get { return _id; }
                set { if (_id == -1) _id = value; }

            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailAddress { get; set; }
        }

        public class Thread
        {
            public int ThreadId { get; set; }
            public string Topic { get; set; }
            public string Text { get; set; }
            public string UserId { get; set; }
            public int CommentCount { get; set; }
        }

        public class Post
        {
            public int PostId { get; }
            public string Text { get; set; }
            public string UserId { get; set; }
            public string ThreadId { get; set; }
            public string Date { get; set; }
            public User User { get; set; }
            public Thread Thread { get; set; }
        }

        static void Main(string[] args)
        {


            Herman HermanObject = new Herman();

            SqliteThreadRepository repo = new SqliteThreadRepository();
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

        public class SqliteThreadRepository
        {
            private const string _connectionString = "Data Source=.\\Forum.db";

            public void PrintVersion()
            {
                using var connection = new SqliteConnection(_connectionString);

                System.Console.WriteLine(connection.ServerVersion);
            }
        }
    }
}
