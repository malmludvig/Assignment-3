using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWithForumDB
{

    public class Thread
    {
        public int ThreadId { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int CommentCount { get; set; }
    }

    class SqliteThreadRepository
    {

        private const string _connectionString = "Data Source=.\\Forum.db";


        public List<Thread> GetThreads()
        {
            using var connection = new SqliteConnection(_connectionString);
            var output = connection.Query<Thread>("SELECT * FROM Threads");// Lägga till parameter substitution
            return output.ToList();
        }

        public void AddThread(Thread thread)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "INSERT INTO threads (Topic,Text) VALUES " +
                $"(@Topic, @Text)";
            var result = connection.Execute(sql, thread);
        }

        public Thread GetThreadWithId(int id) //Parameter substitution
        {
            using var connection = new SqliteConnection(_connectionString);
            var query = "SELECT * FROM Threads WHERE ThreadId = @Id";
            return connection.QuerySingle<Thread>(query, new { Id = id });
        }

        //SELECT COUNT(*) FROM Posts JOIN Threads ON Posts.ThreadId = Threads.ThreadId WHERE threads.ThreadId = 2;

        public Thread CountPostsInThread(int id) //Parameter substitution
        {
            using var connection = new SqliteConnection(_connectionString);
            var query = "SELECT * FROM Threads WHERE ThreadId = @Id";
            return connection.QuerySingle<Thread>(query, new { Id = id });
        }
    }
}
