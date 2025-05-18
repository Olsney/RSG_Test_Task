using Content.Features.AIModule.Scripts.Entity;
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
        private readonly PlayerEntityModel _playerEntityModel;

        public GameUIFactory(DiContainer container, IStorage storage, PlayerEntityModel playerEntityModel)
        {
            _container = container;
            _storage = storage;
            _playerEntityModel = playerEntityModel;
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
            
            Object.DontDestroyOnLoad(instance);
        }

        private HealthPresenter CreateHealthPresenter(GameUIView gameUIView) => 
            new(gameUIView.HealthView, _playerEntityModel);

        private InventoryPresenter CreateInventoryPresenter(GameUIView gameUIView) =>
            new(gameUIView.InventoryView, _storage);
    }
}