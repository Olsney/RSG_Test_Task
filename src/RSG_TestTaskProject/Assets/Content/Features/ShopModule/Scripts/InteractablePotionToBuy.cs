using Content.Features.AIModule.Scripts.Entity;
using Content.Features.InteractionModule;
using Content.Features.PlayerData.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.ShopModule.Scripts
{
    public class InteractablePotionToBuy : MonoBehaviour, IInteractable
    {
        private const int Price = 20;
        private const ItemType ItemToBuy = ItemType.Potion;

        private MoneyModel _moneyModel;
        private IItemFactory _itemFactory;
        private IStorage _playerStorage;

        [Inject]
        public void Construct(
            MoneyModel moneyModel,
            IItemFactory itemFactory)
        {
            _moneyModel = moneyModel;
            _itemFactory = itemFactory;
        }

        public void Interact(IEntity entity)
        {
            IStorage storage = entity.GetContext().Storage;

            if (!CanPay())
                return;

            Item item = _itemFactory.GetItem(ItemToBuy);

            if (storage.TryAddItem(item) == false)
                return;


            _moneyModel.Pay(Price);
            Destroy(gameObject);
        }

        private bool CanPay() => 
            _moneyModel.CurrentMoney >= Price;
    }
}