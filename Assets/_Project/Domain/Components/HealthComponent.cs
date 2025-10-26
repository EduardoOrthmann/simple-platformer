namespace _Project.Domain.Components
{
    [System.Serializable]
    public struct HealthComponent
    {
        public int current;
        public int max;
        public bool IsDead => current <= 0;
    }
}