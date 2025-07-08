using System;
using UnityEngine;

namespace Player
{
    public interface IInputService
    {
        event Action OnFire;
        event Action<Vector2> OnMove;
    }
}