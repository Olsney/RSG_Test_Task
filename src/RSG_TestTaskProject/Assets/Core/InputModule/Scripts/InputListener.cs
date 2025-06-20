﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.InputModule.Scripts {
    public class InputListener : IInputListener, IInitializable, IDisposable {
        private const string PLAYER_ACTION_MAP = "Player";
        private const string INTERACTION_ACTION = "Interaction";
        private const string HEAL_ACTION = "Heal";
        private readonly InputActionAsset _inputActions;
        private InputAction _interactionAction;
        private InputAction _healPressedAction;
        public event Action<Vector2> OnInteractionPerformed;
        public event Action<Vector2> OnInteractionStarted;
        public event Action<Vector2> OnInteractionCanceled;
        public event Action HealPressed;

        public InputListener(InputActionAsset inputActionAsset) =>
            _inputActions = inputActionAsset;

        public void Initialize() {
            _inputActions.Enable();
            _interactionAction = _inputActions.FindActionMap(PLAYER_ACTION_MAP).FindAction(INTERACTION_ACTION);
            _healPressedAction = _inputActions.FindActionMap(PLAYER_ACTION_MAP).FindAction(HEAL_ACTION);
            _interactionAction.performed += OnInteraction;
            _interactionAction.started += OnInteraction;
            _interactionAction.canceled += OnInteraction;
            _healPressedAction.performed += OnHealPerformed;
        }

        public void Dispose() {
            _inputActions.Disable();
            _interactionAction.performed -= OnInteraction;
            _interactionAction.started -= OnInteraction;
            _interactionAction.canceled -= OnInteraction;
            _healPressedAction.performed -= OnHealPerformed;

        }

        public void OnInteraction(InputAction.CallbackContext context) {
            if (context.performed)
                OnInteractionPerformed?.Invoke(Mouse.current.position.ReadValue());

            if (context.started)
                OnInteractionStarted?.Invoke(Mouse.current.position.ReadValue());

            if (context.canceled)
                OnInteractionCanceled?.Invoke(Mouse.current.position.ReadValue());
        }

        private void OnHealPerformed(InputAction.CallbackContext obj) => 
            HealPressed?.Invoke();

        public void OnNavigate(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnSubmit(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnCancel(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnPoint(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnClick(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnRightClick(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnMiddleClick(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnScrollWheel(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnTrackedDevicePosition(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }

        public void OnTrackedDeviceOrientation(InputAction.CallbackContext context) {
            throw new NotImplementedException();
        }
    }
}