using UnityEngine;

namespace _Project.Application.Interfaces
{
    public interface IMovementService
    {
        void Move(Transform entity, Vector2 input, float speed);
        void Jump(Rigidbody2D rb, float jumpForce);
    }
}