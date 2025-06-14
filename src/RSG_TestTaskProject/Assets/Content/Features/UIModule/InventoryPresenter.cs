﻿using Content.Features.StorageModule.Scripts;

namespace Content.Features.UIModule
{
    public class InventoryPresenter : Presenter<InventoryView> {
        private IStorage _storage;

        public InventoryPresenter(InventoryView view, IStorage storage) : base(view)
        {
            _storage = storage;
        }

        public override void Initialize() {
            UpdateView();
            
            _storage.OnItemAdded += OnItemChanged;
            _storage.OnItemRemoved += OnItemChanged;
        }

        public override void Dispose() {
            _storage.OnItemAdded -= OnItemChanged;
            _storage.OnItemRemoved -= OnItemChanged;
        }

        private void OnItemChanged(Item _) =>
            UpdateView();

        private void UpdateView() {
            View.SetItemInfo(itemsCount: _storage.GetAllItems().Count,
                currentWeight: _storage.CurrentWeight,
                maxWeight: _storage.MaxWeight);
        }
    }
}