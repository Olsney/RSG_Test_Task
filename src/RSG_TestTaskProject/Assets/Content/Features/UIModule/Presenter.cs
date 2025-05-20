using System;
using Zenject;

namespace Content.Features.UIModule
{
    public abstract class Presenter<T> : IInitializable, IDisposable
    {
        protected Presenter(T view) {
            View = view;
        }

        protected T View { get; }
        
        public abstract void Initialize();

        public abstract void Dispose();
    }
}