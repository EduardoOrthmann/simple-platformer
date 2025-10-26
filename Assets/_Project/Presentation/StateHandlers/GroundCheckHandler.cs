using _Project.Application.States;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.StateHandlers
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundCheckHandler : MonoBehaviour
    {
        [Inject] private PlayerState _playerState;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _playerState.IsGrounded = true;
                _playerState.IsJumping = false;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _playerState.IsGrounded = false;
            }
        }
    }
}