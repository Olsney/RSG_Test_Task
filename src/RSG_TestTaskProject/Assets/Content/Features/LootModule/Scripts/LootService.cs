using Content.Features.StorageModule.Scripts;
using UnityEngine;

namespace Content.Features.LootModule.Scripts
{
    public class LootService : ILootService
    {
        private IItemFactory _itemFactory;

        public LootService(IItemFactory itemFactory) =>
            _itemFactory = itemFactory;

        public int CollectLoot(Loot loot, IStorage storage)
        {
            int collectedCount = 0;

            foreach (ItemType itemType in loot.GetItemsInLoot())
            {
                if (IsItemCollected(storage, itemType)) 
                    collectedCount++;
            }

            return collectedCount;
        }

        private bool IsItemCollected(IStorage storage, ItemType itemType) =>
            storage.TryAddItem(_itemFactory.GetItem(itemType));
    }
}