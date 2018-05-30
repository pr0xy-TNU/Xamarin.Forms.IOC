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
    public class UsersListPageModel : BaseUserPageModel
    {
        #region Commands
        public ICommand AddUserCommand;
        public ICommand DeleteAllUsersCommand;
        #endregion

        #region Fields
        public User _selectedUser;
        #endregion


        public UsersListPageModel(IUserRepository repo, IValidator validator, IUserDialogs dialogs) : base(repo, validator, dialogs)
        {
            AddUserCommand = new Command(async () => await AddUserCommandExecute());
            DeleteAllUsersCommand = new Command(async () => await DeleteAllUsersCommandExecute());
        }

        public async Task AddUserCommandExecute() => await CoreMethods.PushPageModel<AddUserPageModel>();


        public async Task DeleteAllUsersCommandExecute()
        {
            bool IsAccepted = await CoreMethods.DisplayAlert("Delete All Users", "Do you whant delete all users?", "Yes", "No");
            if (IsAccepted)
            {
                _userRepository.DelteAll();
                await CoreMethods.PushPageModel<AddUserPageModel>();
            }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            FetchAllUsers();
        }

        public void FetchAllUsers()
        {
            UsersList = _userRepository.FindAll();
        }


        public async void ShowUserDatailsById(int id)
        {
            await CoreMethods.PushPageModel<UserDatailsPageModel>();
        }

        public User SelectedUserItem
        {
            get => _selectedUser;
            set
            {
                if (value != null)
                {
                    _selectedUser = value;
                    RaisePropertyChanged("SelectedUserItem");
                    ShowUserDatailsById(_selectedUser.Id);
                }
            }
        }
    }
}
