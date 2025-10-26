namespace _Project.Application.States
{
    public class PlayerState
    {
        public bool IsGrounded { get; set; } = true;
        public bool IsJumping { get; set; }
        public bool IsFalling { get; set; }
        public bool IsRunning { get; set; }
        public bool IsAttacking { get; set; }
        public bool IsHurt { get; set; }
        public bool IsDead { get; set; } = false;
    }
}