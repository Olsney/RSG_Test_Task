using System;
using System.Collections.Generic;

namespace Content.Features.StorageModule.Scripts
{
    public interface IStorage {
        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        float CurrentWeight { get; }
        float MaxWeight { get; }
        public List<Item> GetAllItems();

        public bool TryAddItem(Item item);
        public void AddItems(List<Item> items);

        public void RemoveItem(Item item);
        public void RemoveItems(List<Item> items);

        public void RemoveAllItems();
    }
}