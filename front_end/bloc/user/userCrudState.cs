namespace FrontEnd.Bloc.UserCrud
{
    public class UserCrudState
    {
        public bool IsSaving { get; }
        public bool IsSaved { get; }
        public bool HasFailure { get; }

        public UserCrudState(
            bool isSaving = false,
            bool isSaved = false,
            bool hasFailure = false)
        {
            IsSaving = isSaving;
            IsSaved = isSaved;
            HasFailure = hasFailure;
        }

        public UserCrudState CopyWith(
            bool? isSaving = null,
            bool? isSaved = null,
            bool? hasFailure = null)
        {
            return new UserCrudState(
                isSaving: isSaving ?? this.IsSaving,
                isSaved: isSaved ?? this.IsSaved,
                hasFailure: hasFailure ?? this.HasFailure
            );
        }
    }
}
