namespace Content.Features.UIModule
{
    public class Presenter<T>
    {
        public Presenter(T view)
        {
            View = view;
        }

        protected T View { get; }
    }
}