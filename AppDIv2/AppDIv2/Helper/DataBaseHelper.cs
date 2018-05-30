using System.Collections.Generic;
using AppDI.Helper;
using SQLite;
using Xamarin.Forms;
using AppDI.Models;
using System.Linq;
using System;
using SQLite.Net;

namespace AppDIv2.Helper
{
    public class DataBaseHelper
    {

        static SQLiteConnection connection;
        public const string DATABASE_NAME = "app_di.db";

        public DataBaseHelper()
        {
            connection = DependencyService.Get<ISQLiteConnection>().GetConnection();
            connection.CreateTable<User>();
        }

        public List<User> GetALLData()
        {
            return (from data in connection.Table<User>() select data).ToList();
        }

        public User GetUserById(int id) => connection.Table<User>().FirstOrDefault(item => item.Id == id);

        public void DeteleAll() => connection.DeleteAll<User>();

        public void DeleteById(int id) => connection.Delete<User>(id);

        public void AddUser(User user) => connection.Insert(user);

        public void UpdateUser(User user) => connection.Update(user);

    }
}
