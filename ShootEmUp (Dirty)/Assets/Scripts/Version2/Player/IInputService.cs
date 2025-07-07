using System;
using UnityEngine;

namespace Version2.Player
{
    public interface IInputService
    {
        event Action OnFire;
        Vector2 MoveDirection { get; }
    }
}