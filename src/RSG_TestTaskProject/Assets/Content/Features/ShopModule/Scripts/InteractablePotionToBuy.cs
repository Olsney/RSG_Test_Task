using Content.Features.AIModule.Scripts.Entity;
using Content.Features.InteractionModule;
using Content.Features.PlayerData.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.ShopModule.Scripts
{
    public class InteractablePotionToBuy : MonoBehaviour, IInteractable {
        private const int PRICE = 20;
        private const ItemType ITEM_TO_BUY = ItemType.Potion;

        private MoneyModel _moneyModel;
        private IItemFactory _itemFactory;
        private IStorage _playerStorage;

        [Inject]
        public void InjectDependencies(
            MoneyModel moneyModel,
            IItemFactory itemFactory) {
            _moneyModel = moneyModel;
            _itemFactory = itemFactory;
        }

        public void Interact(IEntity entity) {
            IStorage storage = entity.GetContext().Storage;

            if (!CanPay())
                return;

            Item item = _itemFactory.GetItem(ITEM_TO_BUY);

            if (storage.TryAddItem(item) == false)
                return;


            _moneyModel.Pay(PRICE);
            Destroy(gameObject);
        }

        private bool CanPay() => 
            _moneyModel.CurrentMoney >= PRICE;
    }
}