using System;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Forum
{
    class Program
    {

        static void Main(string[] args)
        {
            var repo = new SqlitePersonRepository();
            repo.Dummy();

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

        public class SqlitePersonRepository
        {
            private const string _connectionString = "Data Source=.\\Forum.db";

            public void Dummy()
            {
                using var connection = new SqliteConnection(_connectionString);

                System.Console.WriteLine(connection.ServerVersion);
            }
        }
    }
}
