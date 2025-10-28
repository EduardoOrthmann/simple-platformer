using System;

namespace _Project.Presentation.Scripts.Shared
{
    public readonly struct AnimationBinding
    {
        public int Hash { get; }
        public Func<bool> Condition { get; }

        public AnimationBinding(int hash, Func<bool> condition)
        {
            Hash = hash;
            Condition = condition;
        }
    }
}