using _Project.Presentation.Scripts.Shared;
using _Project.Presentation.Scripts.States;

namespace _Project.Presentation.Scripts.StateHandlers
{
    public class PlayerAnimatorSystem : BaseAnimatorSystem<PlayerAnimationState>
    {
        public void PlayAttack() => Fsm.ChangeState(Animations.Attack);
        public void PlayDash() => Fsm.ChangeState(Animations.Dash);
        public void PlaySlide() => Fsm.ChangeState(Animations.Slide);
        public void PlayWallSlide() => Fsm.ChangeState(Animations.WallSlide);
    }
}