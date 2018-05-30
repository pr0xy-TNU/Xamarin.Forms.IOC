using System;
using System.Collections.Generic;
using System.Text;
using AppDI.Models;
using AppDIv2.Helper;

namespace AppDIv2.repo
{
    public class UserRepository : IUserRepository
    {
        DataBaseHelper _databaseHelper;

        public UserRepository() => _databaseHelper = new DataBaseHelper();

        public void DeleteUserById(int id) => _databaseHelper.DeleteById(id);

        public void DelteAll() => _databaseHelper.DeteleAll();

        public List<User> FindAll() => _databaseHelper.GetALLData();

        public User FindUserById(int id) => _databaseHelper.GetUserById(id);

        public void InsertUser(User user) => _databaseHelper.AddUser(user);

        public void UpdateUser(User user) => _databaseHelper.UpdateUser(user);

    }
}
