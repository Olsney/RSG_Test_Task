using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Content.Features.UIModule
{
    public class InventoryViewSpawner : IInitializable
    {
        private readonly DiContainer _container;

        public InventoryViewSpawner(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            LoadUIAsync();
        }

        private async void LoadUIAsync()
        {
            GameObject prefab = await Addressables.LoadAssetAsync<GameObject>("InventoryUI").Task;

            GameObject instance = _container.InstantiatePrefab(prefab);
            _container.InjectGameObject(instance);
            
            Object.DontDestroyOnLoad(instance);
        }
    }
}