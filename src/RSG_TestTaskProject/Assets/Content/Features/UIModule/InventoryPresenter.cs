using System;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.UIModule
{
    public class InventoryPresenter : MonoBehaviour
    {
        [SerializeField] private InventoryView _view;
        
        private IStorage _storage;

        [Inject]
        public void Construct(IStorage storage)
        {
            _storage = storage;

            _storage.OnItemAdded += OnItemChanged;
            _storage.OnItemRemoved += OnItemChanged;

            UpdateView();
        }

        public void OnDestroy()
        {
            _storage.OnItemAdded -= OnItemChanged;
            _storage.OnItemRemoved -= OnItemChanged;
        }

        private void OnItemChanged(Item _) =>
            UpdateView();

        private void UpdateView()
        {
            _view.SetItemInfo(itemsCount: _storage.GetAllItems().Count,
                currentWeight: _storage.CurrentWeight,
                maxWeight: _storage.MaxWeight);
        }
    }
}