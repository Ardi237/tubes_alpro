using System;
using FrontEnd.Bloc.UserCrud;
using FrontEnd.Models;
using FrontEnd.Repository;

namespace FrontEnd.UI
{
    public class UserCrudPage
    {
        private readonly UserCrudBloc _bloc;

        public UserCrudPage(UserCrudBloc bloc)
        {
            _bloc = bloc;
        }

        public async Task ShowAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== USER CRUD PAGE ==========\n");
                Console.WriteLine("[1] Insert User");
                Console.WriteLine("[2] Update User");
                Console.WriteLine("[3] Delete User");
                Console.WriteLine("[0] Back to Main Menu");
                Console.Write("\nChoose option: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        await InsertUser();
                        break;
                    case "2":
                        await UpdateUser();
                        break;
                    case "3":
                        await DeleteUser();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }

        private async Task InsertUser()
        {
            Console.Clear();
            Console.WriteLine("=== INSERT USER ===");

            Console.Write("Full Name     : ");
            string full = Console.ReadLine() ?? "";

            Console.Write("Email         : ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Phone Number  : ");
            string phone = Console.ReadLine() ?? "";

            Console.Write("Password Hash : ");
            string pass = Console.ReadLine() ?? "";

            var model = new UserCrudModel(
                0, full, email, phone, pass
            );

            await _bloc.Dispatch(new UserCreateEvent(model));

            Console.WriteLine(_bloc.State.HasFailure
                ? "\n❌ Insert Failed!"
                : "\n✅ Insert Success!");
        }

        private async Task UpdateUser()
        {
            Console.Clear();
            Console.WriteLine("=== UPDATE USER ===");

            Console.Write("User ID       : ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Full Name     : ");
            string full = Console.ReadLine() ?? "";

            Console.Write("Email         : ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Phone Number  : ");
            string phone = Console.ReadLine() ?? "";

            Console.Write("Password Hash : ");
            string pass = Console.ReadLine() ?? "";

            var model = new UserCrudModel(
                id, full, email, phone, pass
            );

            await _bloc.Dispatch(new UserUpdateEvent(model));

            Console.WriteLine(_bloc.State.HasFailure
                ? "\n❌ Update Failed!"
                : "\n✅ Update Success!");
        }

        private async Task DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("=== DELETE USER ===");

            Console.Write("User ID : ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            await _bloc.Dispatch(new UserDeleteEvent(id));

            Console.WriteLine(_bloc.State.HasFailure
                ? "\n❌ Delete Failed!"
                : "\n✅ Delete Success!");
        }
    }
}
