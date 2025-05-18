using Content.Features.DamageablesModule.Scripts;

namespace Content.Features.UIModule
{
    internal class HealthPresenter : Presenter<HealthView>
    {
        private readonly HealthView _view;
        private readonly HealthProvider _healthProvider;

        public HealthPresenter(HealthView view, HealthProvider healthProvider) : base(view)
        {
            _view = view;
            _healthProvider = healthProvider;
            
            _healthProvider.HealthChanged += OnHealthChanged;
            UpdateView(_healthProvider.CurrentHealth);
        }

        private void OnHealthChanged(float health) =>
            UpdateView(health);

        private void UpdateView(float health) => 
            _view.SetHealth(health);
    }
}