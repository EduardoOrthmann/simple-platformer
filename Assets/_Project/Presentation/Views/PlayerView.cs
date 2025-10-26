using UnityEngine;

namespace _Project.Presentation.Views
{
    public class PlayerView : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int Running = Animator.StringToHash("Run");
        private static readonly int Hurt = Animator.StringToHash("Hurt");
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int Jumping = Animator.StringToHash("Jump");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Falling = Animator.StringToHash("Fall");

        private void Awake() => _animator = GetComponent<Animator>();

        public void PlayHurt() => _animator.SetTrigger(Hurt);
        public void PlayDeath() => _animator.SetTrigger(Death);
        public void PlayAttack() => _animator.SetTrigger(Attack);
        public void SetRunning(bool isRunning) => _animator.SetBool(Running, isRunning);
        public void SetJumping(bool isJumping) => _animator.SetBool(Jumping, isJumping);
        public void SetFalling(bool isFalling) => _animator.SetBool(Falling, isFalling);
    }
}