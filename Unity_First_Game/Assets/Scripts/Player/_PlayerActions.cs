using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace roguelike.Player
{
    public class _PlayerActions : MonoBehaviour , IPlayerInput
    {
        PlayerInputActions _inputActions;

        public bool IsInteracting { get; private set;}


        void Awake()
        {
            _inputActions = new PlayerInputActions();
        }

        void OnEnable()
        {
            _inputActions.Player.Interact.performed += OnInteractButton;

        }

        void OnDisable()
        {
            _inputActions.Player.Interact.performed -= OnInteractButton;
        }

        void OnInteractButton(InputAction.CallbackContext context)
        {
            float value = context.ReadValue<float>();
            IsInteracting = value >= 0.15f;
        }

    }
}
