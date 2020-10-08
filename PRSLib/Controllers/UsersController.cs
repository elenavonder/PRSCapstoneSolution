using Microsoft.Data.SqlClient;
using PRSLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRSLib.Controllers
{
    public class UsersController
    {
        public PrsConnection prsConnection { get; set; } = null;//instance of PRS class NOT Sql

        public UsersController(PrsConnection prsConnection)
        {
            this.prsConnection = prsConnection;
        }

        public int Update (User user)
        {
            var sql = "UPDATE Users SET" +
                " Username = @Username," +
                " Password = @Password," +
                " Firstname = @Firstname," +
                " Lastname = @Lastname," +
                " PhoneNumber = @Phone," + //The left side needs to be the same as SQL
                " Email = @Email," +
                " IsReviewer = @IsReviewer," +
                " IsAdmin = @IsAdmin" +
                " WHERE Id = @Id;";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            cmd.Parameters.AddWithValue("@Id", user.Id);

            return cmd.ExecuteNonQuery();
        }

        public int Insert (User user)
        {
            var sql = "INSERT Users (Username, Password, Firstname, Lastname, PhoneNumber, Email, IsReviewer, IsAdmin)" +
                " VALUES (@Username, @Password, @Firstname, @Lastname, @Phone, @Email, @IsReviewer, @IsAdmin);";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
            cmd.Parameters.AddWithValue("@Phone", user.Phone);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@IsReviewer", user.IsReviewer);
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

            return cmd.ExecuteNonQuery();
        }

        public User GetUser(int Id)
        {
            var sql = "SELECT * From Users Where Id = @Id";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            cmd.Parameters.AddWithValue("@Id", Id);
            var sqlDataReader = cmd.ExecuteReader();
            if (!sqlDataReader.HasRows)
                return null;
            sqlDataReader.Read();
            var user = new User();

            user.Id = Convert.ToInt32(sqlDataReader["Id"]);
            user.Username = Convert.ToString(sqlDataReader["Username"]);
            user.Password = Convert.ToString(sqlDataReader["Password"]);
            user.Firstname = Convert.ToString(sqlDataReader["Firstname"]);
            user.Lastname = Convert.ToString(sqlDataReader["Lastname"]);
            user.Phone = Convert.ToString(sqlDataReader["PhoneNumber"]);
            user.Email = Convert.ToString(sqlDataReader["Email"]);
            user.IsAdmin = Convert.ToBoolean(sqlDataReader["IsAdmin"]);
            user.IsReviewer = Convert.ToBoolean(sqlDataReader["IsReviewer"]);

            sqlDataReader.Close();
            return user;
        }


        public List<User> GetUsers()
        {
            var sql = "SELECT * from Users;";
            var cmd = new SqlCommand(sql, prsConnection.sqlConnection);
            var users = new List<User>();
            var sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var user = new User();
                user.Id = Convert.ToInt32(sqlDataReader["Id"]);
                user.Username = Convert.ToString(sqlDataReader["Username"]);
                user.Password = Convert.ToString(sqlDataReader["Password"]);
                user.Firstname = Convert.ToString(sqlDataReader["Firstname"]);
                user.Lastname = Convert.ToString(sqlDataReader["Lastname"]);
                user.Phone = Convert.ToString(sqlDataReader["PhoneNumber"]);
                user.Email = Convert.ToString(sqlDataReader["Email"]);
                user.IsAdmin = Convert.ToBoolean(sqlDataReader["IsAdmin"]);
                user.IsReviewer = Convert.ToBoolean(sqlDataReader["IsReviewer"]);

                users.Add(user);
            }
            sqlDataReader.Close();
            return users;
        }
    }
}
