using System.Threading.Tasks;
using FrontEnd.Models;
using FrontEnd.Repository;

namespace FrontEnd.Bloc.UserCrud
{
    public class UserCrudBloc
    {
        private readonly UserCrudRepository _repository;

        public UserCrudState State { get; private set; }

        public UserCrudBloc(UserCrudRepository repository)
        {
            _repository = repository;
            State = new UserCrudState();
        }

        public async Task Dispatch(UserCrudEvent evt)
        {
            switch (evt)
            {
                case UserCreateEvent createEvt:
                    await OnCreate(createEvt);
                    break;

                case UserUpdateEvent updateEvt:
                    await OnUpdate(updateEvt);
                    break;

                case UserDeleteEvent deleteEvt:
                    await OnDelete(deleteEvt);
                    break;
            }
        }

        private async Task OnCreate(UserCreateEvent evt)
        {
            State = State.CopyWith(isSaving: true, isSaved: false);

            var result = await _repository.Create(evt.Record);

            State = State.CopyWith(
                isSaving: false,
                isSaved: true,
                hasFailure: !result.Success
            );
        }

        private async Task OnUpdate(UserUpdateEvent evt)
        {
            State = State.CopyWith(isSaving: true, isSaved: false);

            var result = await _repository.Update(evt.Record);

            State = State.CopyWith(
                isSaving: false,
                isSaved: true,
                hasFailure: !result.Success
            );
        }

        private async Task OnDelete(UserDeleteEvent evt)
        {
            State = State.CopyWith(isSaving: true, isSaved: false);

            var result = await _repository.Delete(evt.UserId);

            State = State.CopyWith(
                isSaving: false,
                isSaved: true,
                hasFailure: !result.Success
            );
        }
    }
}
