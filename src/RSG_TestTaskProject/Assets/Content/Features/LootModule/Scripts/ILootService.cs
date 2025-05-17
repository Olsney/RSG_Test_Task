using Content.Features.StorageModule.Scripts;

namespace Content.Features.LootModule.Scripts {
    public interface ILootService {
        int CollectLoot(Loot loot, IStorage storage);
    }
}