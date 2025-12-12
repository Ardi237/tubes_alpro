using System.Collections.Generic;
using FrontEnd.Models;

namespace FrontEnd.Bloc.UserList
{
    public class UserListState
    {
        public bool IsLoading { get; }
        public bool IsLoaded { get; }
        public bool HasFailure { get; }

        public List<UserListModel>? Users { get; }
        public UserListModel? SelectedUser { get; }

        public UserListState(
            bool isLoading = false,
            bool isLoaded = false,
            bool hasFailure = false,
            List<UserListModel>? users = null,
            UserListModel? selectedUser = null)
        {
            IsLoading = isLoading;
            IsLoaded = isLoaded;
            HasFailure = hasFailure;
            Users = users;
            SelectedUser = selectedUser;
        }

        public UserListState CopyWith(
            bool? isLoading = null,
            bool? isLoaded = null,
            bool? hasFailure = null,
            List<UserListModel>? users = null,
            UserListModel? selectedUser = null)
        {
            return new UserListState(
                isLoading: isLoading ?? this.IsLoading,
                isLoaded: isLoaded ?? this.IsLoaded,
                hasFailure: hasFailure ?? this.HasFailure,
                users: users ?? this.Users,
                selectedUser: selectedUser ?? this.SelectedUser
            );
        }
    }
}
