using _Project.Application.Interfaces;
using UnityEngine;

namespace _Project.Infrastructure.Services
{
    public class MovementService : IMovementService
    {
        public void Move(Transform entity, Vector2 input, float speed)
        {
            Vector3 movement = new(input.x, 0f, 0f);
            entity.Translate(movement.normalized * speed * Time.deltaTime);
        }

        public void Jump(Rigidbody2D rb, float jumpForce)
        {
            if (rb == null) return;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}