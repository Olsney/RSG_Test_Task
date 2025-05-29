using UnityEngine;

namespace Content.Features.PrefabSpawner.Scripts {
    public interface IPrefabsFactory {
        public GameObject Create(string prefabName);
        public GameObject Create(string prefabName, Vector3 position);
    }
}