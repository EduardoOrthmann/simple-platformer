using _Project.Presentation.Scripts.Animation;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Scripts.Shared
{
    [RequireComponent(typeof(Animator))]
    public abstract class BaseAnimatorSystem<T> : MonoBehaviour where T : IAnimationState
    {
        protected AnimationStateMachine Fsm;
        protected T Animations;
        private Animator _animator;

        [Inject]
        public void Construct(T animations)
        {
            Animations = animations;
        }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            Fsm = new AnimationStateMachine(_animator);
        }

        protected virtual void Update()
        {
            UpdateAnimation();
        }

        protected virtual void UpdateAnimation()
        {
            foreach (var binding in Animations.StateMachineBindings)
            {
                if (!binding.Condition()) continue;
                Fsm.ChangeState(binding.Hash);
                return;
            }

            Fsm.ChangeState(Animations.Idle);
        }
    }
}