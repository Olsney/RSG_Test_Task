using Content.Features.DamageablesModule.Scripts;
using Content.Features.StorageModule.Scripts;
using System.Linq;

namespace Content.Features.UIModule
{
    public class HealPresenter
    {
        private readonly HealView _healView;
        private readonly IStorage _storage;
        private readonly HealthProvider _healthProvider;

        public HealPresenter(HealView healView, IStorage storage, HealthProvider healthProvider)
        {
            _healView = healView;
            _storage = storage;
            _healthProvider = healthProvider;

            _healView.HealClicked += OnHealClicked;
            _storage.OnItemAdded += OnItemsChanged;
            _storage.OnItemRemoved += OnItemsChanged;
        }

        private void OnHealClicked() => 
            UsePotion();

        private void UsePotion()
        {
            Item potion = _storage.GetAllItems().FirstOrDefault(i => i.ItemType == ItemType.Potion);

            if (potion == null || potion.HealValue <= 0)
                return;

            if (GetHealResult(potion) > _healthProvider.MaxHealth)
            {
                _healthProvider.SetHealth(_healthProvider.MaxHealth);

                return;
            }


            _healthProvider.SetHealth(GetHealResult(potion));

            _storage.RemoveItem(potion);
        }

        private float GetHealResult(Item potion) => 
            _healthProvider.CurrentHealth + potion.HealValue;

        private void OnItemsChanged(Item _) =>
            UpdateView();

        private void UpdateView()
        {
            int count = CalculateHealCount();

            _healView.SetHealPotionsInfo(count);
        }

        private int CalculateHealCount()
        {
            int count = 0;

            
            foreach (Item item in _storage.GetAllItems())
            {
                if (item.ItemType == ItemType.Potion)
                    count++;
            }

            return count;
        }
    }
}