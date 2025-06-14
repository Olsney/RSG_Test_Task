﻿using Content.Features.PrefabSpawner.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity {
    public class SellerSpawner : MonoBehaviour {
        private IPrefabsFactory _prefabsFactory;

        [Inject]
        public void InjectDependencies( IPrefabsFactory prefabsFactory) =>
            _prefabsFactory = prefabsFactory;

        private void Start() =>
            _prefabsFactory.Create(Address.Prefabs.Seller, transform.position);
    }
}