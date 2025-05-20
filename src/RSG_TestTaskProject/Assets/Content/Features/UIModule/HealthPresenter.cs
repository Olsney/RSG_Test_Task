using System;
using Content.Features.DamageablesModule.Scripts;
using Zenject;

namespace Content.Features.UIModule
{
    public class HealthPresenter : Presenter<HealthView> {
        private readonly HealthView _view;
        private readonly HealthProvider _healthProvider;

        public HealthPresenter(HealthView view, HealthProvider healthProvider) : base(view) {
            _view = view;
            _healthProvider = healthProvider;
            
        }

        public override void Initialize() {
            UpdateView(_healthProvider.CurrentHealth, _healthProvider.MaxHealth);

            _healthProvider.HealthChanged += OnHealthChanged;
        }

        public override void Dispose() {
            _healthProvider.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float health) =>
            UpdateView(health, _healthProvider.MaxHealth);

        private void UpdateView(float health, float maxHealth) => 
            _view.SetHealth(health, maxHealth);
    }
}