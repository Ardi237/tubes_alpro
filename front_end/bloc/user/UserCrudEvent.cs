using FrontEnd.Models;

namespace FrontEnd.Bloc.UserCrud
{
    public abstract class UserCrudEvent { }

    public class UserCreateEvent : UserCrudEvent
    {
        public UserCrudModel Record { get; }
        public UserCreateEvent(UserCrudModel record) => Record = record;
    }

    public class UserUpdateEvent : UserCrudEvent
    {
        public UserCrudModel Record { get; }
        public UserUpdateEvent(UserCrudModel record) => Record = record;
    }

    public class UserDeleteEvent : UserCrudEvent
    {
        public int UserId { get; }
        public UserDeleteEvent(int userId) => UserId = userId;
    }
}
