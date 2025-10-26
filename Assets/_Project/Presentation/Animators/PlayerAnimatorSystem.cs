using _Project.Application.States;
using _Project.Presentation.Views;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Animators
{
    public class PlayerAnimatorSystem : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;
        [Inject] private PlayerState _state;

        private void Update()
        {
            playerView.SetJumping(_state.IsJumping);
            playerView.SetFalling(_state.IsFalling);
            playerView.SetRunning(_state.IsRunning);
        }

        public void PlayHurt() => playerView.PlayHurt();
        public void PlayDeath() => playerView.PlayDeath();
        public void PlayAttack() => playerView.PlayAttack();
    }
}