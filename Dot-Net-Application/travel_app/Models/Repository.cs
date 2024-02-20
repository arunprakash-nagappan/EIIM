using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using travel.Controllers;
using travel.Models;
public class Repository 
    {
        public static  void Signup(Signup register)
        {
            try
            {
            using(SqlConnection connection = new SqlConnection(getConnection()))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("Insert into user_profile (UserName,Password,Name) values('"+register.Username+"','"+register.Password+"','"+register.Name+"');",connection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("query is inserted");
            }
            }
        catch (SqlException exception)
        {
            Console.WriteLine("Database error: " + exception);
        }
    }
     public static  void Booking(Booking book)
        {
            try
            {
            using(SqlConnection connection = new SqlConnection(getConnection()))
            {
                connection.Open();
                Console.WriteLine("connection is open");

                SqlCommand insertCommand = new SqlCommand("Insert into booking (Username, [From], [To], Date) values('"+book.Username+"','"+book.From+"','"+book.To+"','"+book.Date+"');",connection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("query is inserted");
            }
            }
        catch (SqlException exception)
        {
            Console.WriteLine("Database error: " + exception);
        }
    }
     public static List<Login> GetUserProfiles()
    {
        List<Login> userList = new List<Login>();

        try
        {
            using (SqlConnection connection = new SqlConnection(getConnection()))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM user_profile", connection);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    Login user = new Login();
                    user.Username = sqlReader["UserName"].ToString();
                    user.Password = sqlReader["Password"].ToString();
                    userList.Add(user);
                    // if(x == 0){
                    //     userList.Add(user);
                    // }
                    
                }
                Console.WriteLine("user updated");
                
            }
        }
        catch (SqlException exception)
        {
            Console.WriteLine("Database error: " + exception);
        }
    

        return userList;
    }

    public static bool IsUserValid(Login enteredUser)
    {
        List<Login> userList = GetUserProfiles();

        foreach (Login user in userList)
        {
            if (enteredUser.Username == user.Username && enteredUser.Password == user.Password)
            {
                
                return true; // User is valid
            }
        }

        return false; // User is not valid
    }
    // public static List<Login> GetUserProfiles = new List<Login>();
 
    // public static List<Login> GetUserProfiles(int x)
    // {
    //     try
    //     {
    //         using (SqlConnection Connection = new SqlConnection(getConnection()))
    //         {
    //             Connection.Open();
    //             SqlCommand sqlCommand = new SqlCommand("select * from user_profile", Connection);
    //             SqlDataReader sqlReader = sqlCommand.ExecuteReader();
 
    //             while (sqlReader.Read())
    //             {
    //                 Login user = new Login();
    //                 Console.WriteLine("Entered");
    //                 user.Username = sqlReader["UserName"].ToString();
    //                 user.Password = sqlReader["Password"].ToString();
    //                 if (x == 0)
    //                 {
    //                     GetUserProfiles.Add(user);
    //                 }
    //             }
    //         }
    //     }
 
    //     catch (SqlException exception)
    //     {
    //         Console.WriteLine("Datebase error" + exception);
    //     }
    //     return GetUserProfiles;
    // }
 
 
 
    // public static int IsUserVali(Login user)
    // {
    //     string Username = user.Username;
    //     string Password = user.Password;
    //     List<Login> Detail = GetUserProfiles(1);
    //     foreach (Login Data in Detail)
    //     {
    //         if (String.Equals(Username, Data.Username) && String.Equals(Password, Data.Password))
    //         {
    //             return 1;
    //         }
    //     }
    //     return 2;
    // }
 
    // public static int SignUp(Signup register)
 
    // {
    //     Console.WriteLine("Inside Signup Model");
    //     bool userNameflag = true;
    //     List<Login> Detail = GetUserProfiles(1);
    //     foreach (Login data in detail)
    //     {
    //         Console.WriteLine("Inside Verification");
    //         if (String.Equals(register.Username, register.Password))
    //         {
    //             userNameflag = false;
    //         }
    //     }
 
    //     if (userNameflag == true)
    //     {
    //         using (SqlConnection Connection = new SqlConnection(getConnection()))
    //         {
    //             Connection.Open();
 
    //             SqlCommand insertCommand = new SqlCommand("Insert into user_profile (UserName,Password,Name) values ('" + register.Username + "','" + register.Password + "','" + register.Name + "','" + sign.Email + "');", Connection);
 
    //             insertCommand.ExecuteNonQuery();
    //         }
    //         System.Console.WriteLine("inserted");
    //         return 4;
    //     }
    //     System.Console.WriteLine("UserName Exist");
    //     return 1;
    // }
    
    // public static  void Booking(Booking Book)
    //     {
    //         try
    //         {
    //         using(SqlConnection connection = new SqlConnection(getConnection()))
    //         {
    //             connection.Open();
    //             SqlCommand insertCommand = new SqlCommand("Insert into booking_details (UserName,From,To,Date) values('"+Book.Username+"','"+register.Password+"','"+register.Name+"');",connection);
    //             insertCommand.ExecuteNonQuery();
    //             Console.WriteLine("query is inserted");
    //         }
    //         }
    //     catch (SqlException exception)
    //     {
    //         Console.WriteLine("Database error: " + exception);
    //     }

    //     }
    public static List<Ticket> GetUserTickets(string Username)
    {

        List<Ticket> TicketList = new List<Ticket>();

        try
        {
            using (SqlConnection connection = new SqlConnection(getConnection()))
            {
                
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM booking where Username=@Username", connection);
                sqlCommand.Parameters.AddWithValue("@Username", Username);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    Ticket user = new Ticket();
                    user.Username = sqlReader["UserName"].ToString();
                    user.From = sqlReader["From"].ToString();
                    user.To=sqlReader["To"].ToString();
                    user.Date=sqlReader["Date"].ToString();
                    TicketList.Add(user);
                    // if(x == 0){
                    //     userList.Add(user);
                    // }
                    
                }
                Console.WriteLine("user updated");
                
            }
        }
        catch (SqlException exception)
        {
            Console.WriteLine("Database error: " + exception);
        }
    

        return TicketList;
    }
    public static  void CancelTicket(CancelTicket cancelticket)
        {
            try
            {
            using(SqlConnection connection = new SqlConnection(getConnection()))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM booking where Username=cancelticket.Username');",connection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("query is inserted");
            }
            }
        catch (SqlException exception)
        {
            Console.WriteLine("Database error: " + exception);
        }
    }

        public static string? getConnection()
        {
        var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
        IConfiguration configuration = build.Build();
        string? connectionString = Convert.ToString(configuration.GetConnectionString("DefaultConnection"));
        return connectionString;
        }
    }

