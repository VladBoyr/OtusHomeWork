using System;
using UnityEngine;

namespace Player
{
    public sealed class PlayerInputService : MonoBehaviour, IInputService
    {
        public event Action OnFire;
        public event Action<Vector2> OnMove;

        private void Update()
        {
            this.HandleMovementInput();
            this.HandleFireInput();
        }

        private void HandleMovementInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            this.OnMove?.Invoke(new Vector2(horizontal, 0));
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