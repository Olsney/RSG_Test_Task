﻿using Content.Features.DamageablesModule.Scripts;
using Content.Features.StorageModule.Scripts;
using System.Linq;
using Core.InputModule;
using Core.InputModule.Scripts;

namespace Content.Features.UIModule
{
    public class HealPresenter : Presenter<HealView> {
        private readonly IStorage _storage;
        private readonly HealthProvider _healthProvider;
        private readonly IInputListener _inputListener;

        public HealPresenter(HealView healView, IStorage storage, HealthProvider healthProvider,
            IInputListener inputListener) : base(healView) {
            _storage = storage;
            _healthProvider = healthProvider;
            _inputListener = inputListener;
        }

        public override void Initialize() {
            View.HealClicked += OnHealUsed;
            _inputListener.HealPressed += OnHealUsed;
            _storage.OnItemAdded += OnItemsChanged;
            _storage.OnItemRemoved += OnItemsChanged;

            UpdateView();
        }

        public override void Dispose() {
            View.HealClicked -= OnHealUsed;
            _inputListener.HealPressed -= OnHealUsed;
            _storage.OnItemAdded -= OnItemsChanged;
            _storage.OnItemRemoved -= OnItemsChanged;
        }

        private void OnHealUsed() {
            UsePotion();
        }

        private void UsePotion() {
            Item potion = _storage.GetAllItems().FirstOrDefault(i => i.ItemType == ItemType.Potion);

            if (potion == null || potion.HealValue <= 0)
                return;

            if (GetHealResult(potion) > _healthProvider.MaxHealth) {
                _healthProvider.SetHealth(_healthProvider.MaxHealth);
                _storage.RemoveItem(potion);

                return;
            }


            _healthProvider.SetHealth(GetHealResult(potion));
            _storage.RemoveItem(potion);
        }

        private float GetHealResult(Item potion) => 
            _healthProvider.CurrentHealth + potion.HealValue;

        private void OnItemsChanged(Item _) =>
            UpdateView();

        private void UpdateView() {
            int count = CalculateHealCount();

            View.SetHealPotionsInfo(count);
        }

        private int CalculateHealCount() {
            int count = 0;

            
            foreach (Item item in _storage.GetAllItems()) {
                if (item.ItemType == ItemType.Potion)
                    count++;
            }

            return count;
        }
    }
}