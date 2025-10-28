using UnityEngine;

namespace _Project.Presentation.Scripts.Animation
{
    public class AnimationStateMachine
    {
        private readonly Animator _animator;
        private int _currentStateHash;

        public AnimationStateMachine(Animator animator)
        {
            _animator = animator;
        }

        public void ChangeState(int newStateHash)
        {
            if (_currentStateHash == newStateHash) return;
            _currentStateHash = newStateHash;
            PlayStateAnimation(newStateHash);
        }

        private void PlayStateAnimation(int newStateHash)
        {
            _animator.Play(newStateHash, 0);
            _currentStateHash = newStateHash;
        }
    }
}