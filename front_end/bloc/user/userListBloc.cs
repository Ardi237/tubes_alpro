using System.Threading.Tasks;
using FrontEnd.Repository;
using FrontEnd.Models;

namespace FrontEnd.Bloc.UserList
{
    public class UserListBloc
    {
        private readonly UserListRepository _repository;

        public UserListState State { get; private set; }

        public UserListBloc(UserListRepository repository)
        {
            _repository = repository;
            State = new UserListState();
        }

        public async Task Dispatch(UserListEvent evt)
        {
            switch (evt)
            {
                case LoadUserListEvent listEvt:
                    await OnLoadUserList(listEvt);
                    break;

                case LoadUserDetailEvent detailEvt:
                    await OnLoadUserDetail(detailEvt);
                    break;
            }
        }

        private async Task OnLoadUserList(LoadUserListEvent evt)
        {
            State = State.CopyWith(isLoading: true, isLoaded: false);

            var result = await _repository.GetUserList(evt.SearchText);

            bool failed = result == null;

            State = State.CopyWith(
                isLoading: false,
                isLoaded: !failed,
                hasFailure: failed,
                users: result
            );
        }

        private async Task OnLoadUserDetail(LoadUserDetailEvent evt)
        {
            State = State.CopyWith(isLoading: true, isLoaded: false);

            var result = await _repository.GetUserById(evt.UserId);

            bool failed = result == null;

            State = State.CopyWith(
                isLoading: false,
                isLoaded: !failed,
                hasFailure: failed,
                selectedUser: result
            );
        }
    }
}
