using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumWithForumDB
{
    public class SqliteThreadRepository
    {
        private const string _connectionString = "Data Source=.\\Forum.db";

        public void PrintVersion()
        {
            using var connection = new SqliteConnection(_connectionString);

            System.Console.WriteLine(connection.ServerVersion);
        }
    }


    public class Herman
    {
        public int Number;
    }
}
