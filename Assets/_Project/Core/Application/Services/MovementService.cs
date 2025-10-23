using _Project.Core.Domain.Components;
using UnityEngine;

namespace _Project.Core.Application.Services
{
    public class MovementService
    {
        public void Move(Rigidbody2D rb, MovementData data, float inputX)
        {
            rb.linearVelocity = new Vector2(inputX * data.speed, rb.linearVelocity.y);
        }

        public void Jump(Rigidbody2D rb, MovementData data)
        {
            if (!data.isGrounded) return;

            rb.AddForce(Vector2.up * data.jumpForce, ForceMode2D.Impulse);
            data.isGrounded = false;
        }
    }
}