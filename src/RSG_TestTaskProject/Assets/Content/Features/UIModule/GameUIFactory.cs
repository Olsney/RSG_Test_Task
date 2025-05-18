using Content.Features.AIModule.Scripts.Entity;
using Content.Features.DamageablesModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Content.Features.UIModule
{
    public class GameUIFactory : IInitializable
    {
        private const string UIKey = "GameUI";
        
        private readonly DiContainer _container;
        private readonly IStorage _storage;
        private readonly HealthProvider _healthProvider;
        private readonly MoneyModel _moneyModel;
        private readonly PlayerEntityModel _playerEntityModel;

        public GameUIFactory(DiContainer container, IStorage storage, HealthProvider healthProvider, MoneyModel moneyModel)
        {
            _container = container;
            _storage = storage;
            _healthProvider = healthProvider;
            _moneyModel = moneyModel;
        }

        public void Initialize()
        {
            LoadUIAsync();
        }

        private async void LoadUIAsync()
        {
            GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(UIKey).Task;
            
            GameObject instance = _container.InstantiatePrefab(prefab);
            
            GameUIView gameUIView = instance.GetComponent<GameUIView>();
            
            HealthPresenter healthPresenter = CreateHealthPresenter(gameUIView);
            InventoryPresenter inventoryView = CreateInventoryPresenter(gameUIView);
            MoneyPresenter moneyPresenter = CreateMoneyPresenter(gameUIView);
            
            Object.DontDestroyOnLoad(instance);
        }

        private HealthPresenter CreateHealthPresenter(GameUIView gameUIView) => 
            new(gameUIView.HealthView, _healthProvider);

        private InventoryPresenter CreateInventoryPresenter(GameUIView gameUIView) =>
            new(gameUIView.InventoryView, _storage);
        
        private MoneyPresenter CreateMoneyPresenter(GameUIView gameUIView) =>
            new(gameUIView.MoneyView, _moneyModel);
    }
}