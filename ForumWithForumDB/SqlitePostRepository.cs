﻿using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForumWithForumDB
{

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

    class SqlitePostRepository
    {
        private const string _connectionString = "Data Source=.\\Forum.db";

        public Thread GetThreadWithId(int id) //Parameter substitution
        {
            using var connection = new SqliteConnection(_connectionString);
            var query = "SELECT * FROM Threads WHERE ThreadId = @Id";
            return connection.QuerySingle<Thread>(query, new { Id = id });
        }

        public List<Post> GetPostsFromThread(Thread thread)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM posts AS p " +
            " INNER JOIN Users AS u ON (u.UserId = p.UserId)" +
            " WHERE p.ThreadId = @ThreadId;";

            var posts = connection.Query<Post, User, Post>(sql, (post, user) =>
            {
                //tilldelar User i tabellen med post.user
                post.User = user;
                return post;
            },
            thread,
            splitOn: "UserId");
            return posts.ToList();
        }
    }
}
