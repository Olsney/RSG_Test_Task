using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Random = UnityEngine.Random;

namespace Content.Features.LootModule.Scripts {
    public class LootSpawner : MonoBehaviour {
        [FormerlySerializedAs("_lootToSpawn")] [SerializeField] private List<Loot> _possibleLoots;
        private DiContainer _diContainer;

        [Inject]
        public void InjectDependencies(DiContainer diContainer) =>
            _diContainer = diContainer;
        
        public void SpawnLoot() {
            if (_possibleLoots == null || _possibleLoots.Count == 0)
                return;

            Loot randomLoot = _possibleLoots[Random.Range(0, _possibleLoots.Count)];

            _diContainer.InstantiatePrefab(
                randomLoot.gameObject,
                transform.position,
                Quaternion.identity,
                null);
        }
    }
}