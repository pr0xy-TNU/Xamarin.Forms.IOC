using AppDI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDIv2.repo
{
    public interface IUserRepository
    {
        void DeleteUserById(int id);
        void DelteAll();
        User FindUserById(int id);
        List<User> FindAll();
        void UpdateUser(User user);
        void InsertUser(User user);
    }
}
