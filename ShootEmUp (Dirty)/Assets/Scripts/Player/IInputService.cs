using System;
using UnityEngine;

namespace Player
{
    public interface IInputService
    {
        event Action OnFire;
        Vector2 MoveDirection { get; }
    }
}