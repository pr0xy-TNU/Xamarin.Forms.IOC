using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using AppDI.Models;
using AppDI.Pages;
using AppDIv2.PageModels.Base;
using AppDIv2.repo;
using FluentValidation;
using FreshMvvm;
using Xamarin.Forms;

namespace AppDIv2.PageModels
{
    public class AddUserPageModel : BaseUserPageModel
    {
        public ICommand AddNewUserCommand;
        public ICommand ViewAllContactsCommand;

        public AddUserPageModel(IUserRepository repo, IUserDialogs dialogs, IValidator validator) : base(repo, validator, dialogs)
        {
            _user = new User();
            AddNewUserCommand = new Command(async () => await AddNewUserCommandExecute());
            ViewAllContactsCommand = new Command(async () => await ShowAllContactsCommandExecute());
        }

        public async Task AddNewUserCommandExecute()
        {
            var userValidation = _userValidator.Validate(_user);
            if (userValidation.IsValid)
            {
                bool IsAccepted = await CoreMethods.DisplayAlert("Add User", "Do you whant to save contact?", "Yes", "No");
                if (IsAccepted)
                {
                    _userRepository.InsertUser(_user);
                    await CoreMethods.PushPageModel<UsersListPageModel>();
                }
                else
                {
                    await CoreMethods.DisplayAlert("Add User", userValidation.Errors[0].ErrorMessage, "Ok");
                }
            }
        }

        public async Task ShowAllContactsCommandExecute()
        {
            await CoreMethods.PushPageModel<UsersListPageModel>();
        }

        bool IsViewAll() => _userRepository.FindAll().Count > 0 ? true : false;
    }
}
