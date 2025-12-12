using FrontEnd.UI;
using FrontEnd.Repository;
using FrontEnd.Bloc.UserCrud;
using FrontEnd.Bloc.UserList;

var userCrudRepo = new UserCrudRepository();
var userListRepo = new UserListRepository();

var userCrudBloc = new UserCrudBloc(userCrudRepo);
var userListBloc = new UserListBloc(userListRepo);

var crudPage = new UserCrudPage(userCrudBloc);
var listPage = new UserListPage(userListBloc);

// MAIN MENU
while (true)
{
    Console.Clear();
    Console.WriteLine("========== MAIN MENU ==========\n");
    Console.WriteLine("[1] USER CRUD");
    Console.WriteLine("[2] USER LIST / SEARCH");
    Console.WriteLine("[0] EXIT");
    Console.Write("\nChoose option: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            await crudPage.ShowAsync();
            break;

        case "2":
            await listPage.ShowAsync();
            break;

        case "0":
            return;
    }

    Console.WriteLine("Press ENTER to continue...");
    Console.ReadLine();
}
