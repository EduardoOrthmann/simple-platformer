using System.Collections.Generic;

namespace _Project.Presentation.Scripts.Shared
{
    public interface IAnimationState
    {
        IReadOnlyList<AnimationBinding> StateMachineBindings { get; }
        int Idle { get; }
    }
}