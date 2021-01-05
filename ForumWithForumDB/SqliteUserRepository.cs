using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWithForumDB
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



        class SqliteUserRepository
        {

        private const string _connectionString = "Data Source=.\\Forum.db";

        public List<User> GetUsers()
        {
            using var connection = new SqliteConnection(_connectionString);
            var output = connection.Query<User>("SELECT * FROM Users");
            return output.ToList();
        }

        public void AddUser(User person)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "INSERT INTO Users (FirstName,Lastname,EmailAddress) VALUES " +
                $"(@FirstName, @LastName, @EmailAddress)";
            var result = connection.Execute(sql, person);
        }
    }
}
