namespace FrontEnd.Bloc.UserList
{
    public abstract class UserListEvent { }

    public class LoadUserListEvent : UserListEvent
    {
        public string SearchText { get; }
        public LoadUserListEvent(string searchText)
        {
            SearchText = searchText;
        }
    }

    public class LoadUserDetailEvent : UserListEvent
    {
        public int UserId { get; }
        public LoadUserDetailEvent(int userId)
        {
            UserId = userId;
        }
    }
}
