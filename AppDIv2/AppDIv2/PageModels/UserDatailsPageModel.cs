using Acr.UserDialogs;
using AppDI.Models;
using AppDIv2.PageModels.Base;
using AppDIv2.repo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDIv2.PageModels
{
    public class UserDatailsPageModel : BaseUserPageModel
    {
        public ICommand DeleteUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public UserDatailsPageModel(IUserRepository repo, IValidator validator, IUserDialogs dialogs) : base(repo, validator, dialogs)
        {
            _user = new User();
            DeleteUserCommand = new Command(async () => await DeleteUserCommandExecute());
            UpdateUserCommand = new Command(async () => await UpdateUserCommandExecute());
        }

        public override void Init(object initData)
        {
            _user.Id = (int)initData;
            FetchUserDatails();
        }

        private void FetchUserDatails()
        {
            _user = _userRepository.FindUserById(_user.Id);
        }

        async Task DeleteUserCommandExecute()
        {
            bool IsAccepted = await CoreMethods.DisplayAlert("Delete User", "Do you whant to delete current user? ", "Yes", "No");
            if (IsAccepted)
            {
                _userRepository.DeleteUserById(_user.Id);
                await CoreMethods.PopPageModel();
            }
        }

        async Task UpdateUserCommandExecute()
        {
            var userValidations = _userValidator.Validate(_user);
            if (userValidations.IsValid)
            {
                _userRepository.UpdateUser(_user);
                await CoreMethods.PopPageModel();
            }
            else
            {
                await CoreMethods.DisplayAlert("Update User", userValidations.Errors[0].ErrorMessage, "Ok");
            }
        }

    }
}
