using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using AppDI.Models;
using AppDIv2.repo;
using FluentValidation;
using FreshMvvm;

namespace AppDIv2.PageModels.Base
{
    public class BaseUserPageModel : FreshBasePageModel
    {
        #region Fields
        public User _user;
        public IUserRepository _userRepository;
        public IValidator _userValidator;
        public List<User> _userList;
        public IUserDialogs Dialogs;
        #endregion

        public BaseUserPageModel(IUserRepository repo, IValidator validator, IUserDialogs dialogs)
        {
            _userRepository = repo;
            _userValidator = validator;
            Dialogs = dialogs;
        }

        #region Properties

        public string FirstName
        {
            get => _user.FirstName;
            set
            {
                if (!_user.FirstName.Equals(value))
                {
                    _user.FirstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get => _user.LastName;
            set
            {
                if (!_user.LastName.Equals(value))
                {
                    _user.LastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        public string Email
        {
            get => _user.UserEmail;
            set
            {
                if (!_user.UserEmail.Equals(value))
                {
                    _user.UserEmail = value;
                    RaisePropertyChanged("Email");
                }
            }
        }
        public string Phone
        {
            get => _user.PhoneNumber;
            set
            {
                if (_user.PhoneNumber != value)
                {
                    _user.PhoneNumber = value;
                    RaisePropertyChanged("Phone");
                }
            }
        }

        public int Age
        {
            get => _user.Age;
            set
            {
                if (!_user.Age.Equals(value))
                {
                    _user.Age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        public List<User> UsersList
        {
            get => _userList;
            set
            {
                _userList = value;
                RaisePropertyChanged("UsersList");
            }
        }
        #endregion


        public List<User> GetAll() => _userRepository.FindAll();

    }
}
