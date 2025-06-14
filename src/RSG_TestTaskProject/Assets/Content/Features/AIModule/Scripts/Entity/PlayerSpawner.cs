﻿using Content.Features.PrefabSpawner.Scripts;
using Global.Scripts.Generated;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity {
    public class PlayerSpawner : MonoBehaviour {
        private IPrefabsFactory _prefabsFactory;
        private PlayerEntityModel _playerEntityModel;

        [Inject]
        public void InjectDependencies(IPrefabsFactory prefabsFactory, PlayerEntityModel playerEntityModel) {
            _playerEntityModel = playerEntityModel;
            _prefabsFactory = prefabsFactory;
        }

        private void Start() {
            GameObject playerPrefab = _prefabsFactory.Create(Address.Prefabs.Player, transform.position);
            playerPrefab.transform.position = transform.position;
            _playerEntityModel.PlayerEntity = playerPrefab.GetComponent<IEntity>();
            _prefabsFactory.Create(Address.Prefabs.PlayerCamera);
        }
    }
}