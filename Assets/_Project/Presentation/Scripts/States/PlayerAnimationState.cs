using System.Collections.Generic;
using _Project.Application.States;
using _Project.Presentation.Scripts.Shared;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Scripts.States
{
    public class PlayerAnimationState : IAnimationState
    {
        public IReadOnlyList<AnimationBinding> StateMachineBindings { get; }

        public int Idle { get; } = Animator.StringToHash("Idle");
        public int Run { get; } = Animator.StringToHash("Run");
        public int Attack { get; } = Animator.StringToHash("Attack");
        public int Hurt { get; } = Animator.StringToHash("Hurt");
        public int Death { get; } = Animator.StringToHash("Death");
        public int Jump { get; } = Animator.StringToHash("jump");
        public int JumpToFall { get; } = Animator.StringToHash("JumptoFall");
        public int Fall { get; } = Animator.StringToHash("Fall");
        public int EdgeIdle { get; } = Animator.StringToHash("Edge-Idle");
        public int WallSlide { get; } = Animator.StringToHash("Wall-Slide");
        public int Crouch { get; } = Animator.StringToHash("Croush");
        public int Dash { get; } = Animator.StringToHash("Dash");
        public int DashAttack { get; } = Animator.StringToHash("Dash-Attack");
        public int Slide { get; } = Animator.StringToHash("Slide");
        public int Ladder { get; } = Animator.StringToHash("Ladder");
        public int HurtNoFx { get; } = Animator.StringToHash("Hurt NoEffect");
        public int DeathNoFx { get; } = Animator.StringToHash("Death NoEffect");
        public int DashNoDust { get; } = Animator.StringToHash("Dash NoDust");
        public int DashAtkNoDust { get; } = Animator.StringToHash("Dash-Attack NoDust");
        public int WallSlideNoDust { get; } = Animator.StringToHash("WallSlide NoDust");

        [Inject]
        public PlayerAnimationState(PlayerState playerState)
        {
            StateMachineBindings = new List<AnimationBinding>
            {
                new(Death, () => playerState.IsDead),
                new(Hurt, () => playerState.IsHurt),
                new(Jump, () => playerState.IsJumping),
                new(Fall, () => playerState.IsFalling),
                new(Run, () => playerState.IsRunning),
                new(Attack, () => playerState.IsAttacking)
            };
        }
    }
}