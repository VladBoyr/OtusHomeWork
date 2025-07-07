using System;
using UnityEngine;

namespace Version2.Player
{
    public sealed class PlayerInputService : MonoBehaviour, IInputService
    {
        public event Action OnFire;
        public Vector2 MoveDirection { get; private set; }

        private void Update()
        {
            this.HandleMovementInput();
            this.HandleFireInput();
        }

        private void HandleMovementInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            this.MoveDirection = new Vector2(horizontal, 0);
        }

        private void HandleFireInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.OnFire?.Invoke();
            }
        }
    }
}