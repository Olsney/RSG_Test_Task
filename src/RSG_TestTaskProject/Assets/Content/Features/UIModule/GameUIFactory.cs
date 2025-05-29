using System;
using System.Collections.Generic;
using Content.Features.AIModule.Scripts.Entity;
using Content.Features.DamageablesModule.Scripts;
using Content.Features.PlayerData.Scripts;
using Content.Features.StorageModule.Scripts;
using Core.InputModule;
using Core.InputModule.Scripts;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using Object = UnityEngine.Object;

namespace Content.Features.UIModule
{
    public class GameUIFactory : IInitializable, IDisposable {
        private const string UI_KEY = "GameUI";

        private readonly DiContainer _container;
        private readonly IStorage _storage;
        private readonly HealthProvider _healthProvider;
        private readonly MoneyModel _moneyModel;
        private readonly IInputListener _inputListener;
        private readonly PlayerEntityModel _playerEntityModel;

        private HealthPresenter _healthPresenter;
        private InventoryPresenter _inventoryPresenter;
        private MoneyPresenter _moneyPresenter;
        private HealPresenter _healPresenter;
        private List<IInitializable> _presenters = new List<IInitializable>();


        public GameUIFactory(DiContainer container, IStorage storage, HealthProvider healthProvider,
            MoneyModel moneyModel, IInputListener inputListener) {
            _container = container;
            _storage = storage;
            _healthProvider = healthProvider;
            _moneyModel = moneyModel;
            _inputListener = inputListener;
        }

        public void Initialize() {
            LoadUIAsync();
        }

        private async void LoadUIAsync() {
            GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(UI_KEY).Task;

            GameObject instance = _container.InstantiatePrefab(prefab);

            GameUIView gameUIView = instance.GetComponent<GameUIView>();

            CreatePresenters(gameUIView);

            foreach (IInitializable presenter in _presenters) 
                presenter.Initialize();

            Object.DontDestroyOnLoad(instance);
        }

        private void CreatePresenters(GameUIView gameUIView)
        {
            _presenters.Add(CreateHealthPresenter(gameUIView));
            _presenters.Add(CreateInventoryPresenter(gameUIView));
            _presenters.Add(CreateMoneyPresenter(gameUIView));
            _presenters.Add(CreateHealPresenter(gameUIView));
        }

        private HealthPresenter CreateHealthPresenter(GameUIView gameUIView) =>
            new(gameUIView.HealthView, _healthProvider);

        private InventoryPresenter CreateInventoryPresenter(GameUIView gameUIView) =>
            new(gameUIView.InventoryView, _storage);

        private MoneyPresenter CreateMoneyPresenter(GameUIView gameUIView) =>
            new(gameUIView.MoneyView, _moneyModel);

        private HealPresenter CreateHealPresenter(GameUIView gameUIView) =>
            new(gameUIView.HealView, _storage, _healthProvider, _inputListener);

        public void Dispose() {
            foreach (IInitializable presenter in _presenters) {
                if(presenter is IDisposable disposable) 
                    disposable.Dispose();
            } 
        }
    }
}