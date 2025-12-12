using FrontEnd.Bloc.UserList;
using FrontEnd.Repository;

namespace FrontEnd.UI
{
    public class UserListPage
    {
        private readonly UserListBloc _bloc;

        public UserListPage(UserListBloc bloc)
        {
            _bloc = bloc;
        }


        public async Task ShowAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("============= USER LIST PAGE =============\n");
                Console.WriteLine("[1] Search User (by text)");
                Console.WriteLine("[2] List All Users");
                Console.WriteLine("[3] Find User By ID");
                Console.WriteLine("[0] Back to Main Menu");
                Console.Write("\nChoose option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        await SearchUser();
                        break;
                    case "2":
                        await ListAllUsers();
                        break;
                    case "3":
                        await FindUserById();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }

        private async Task SearchUser()
        {
            Console.Clear();
            Console.WriteLine("===== SEARCH USER =====");
            Console.Write("Search text: ");
            string search = Console.ReadLine()!.Trim();

            await _bloc.Dispatch(new LoadUserListEvent(search));

            if (_bloc.State.HasFailure || _bloc.State.Users == null)
            {
                Console.WriteLine("\n❌ Failed to get users!");
                return;
            }

            Console.WriteLine("\n===== RESULT =====");

            foreach (var u in _bloc.State.Users)
            {
                Console.WriteLine($"• {u.UserId} | {u.FullName} | {u.Email}");
            }
        }

        private async Task ListAllUsers()
        {
            Console.Clear();
            Console.WriteLine("===== ALL USERS =====");

            await _bloc.Dispatch(new LoadUserListEvent(""));

            if (_bloc.State.HasFailure || _bloc.State.Users == null)
            {
                Console.WriteLine("\n❌ Failed loading list!");
                return;
            }

            foreach (var u in _bloc.State.Users)
            {
                Console.WriteLine($"{u.UserId} | {u.FullName} | {u.Email}");
            }
        }

         private async Task FindUserById()
        {
            Console.Clear();
            Console.WriteLine("===== FIND USER BY ID =====");

            Console.Write("Enter User ID: ");
            string input = Console.ReadLine()!.Trim();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("\n❌ Invalid ID format!");
                return;
            }

            await _bloc.Dispatch(new LoadUserDetailEvent(id));

            if (_bloc.State.HasFailure || _bloc.State.SelectedUser == null)
            {
                Console.WriteLine("\n❌ User not found!");
                return;
            }
        }
    }
}
