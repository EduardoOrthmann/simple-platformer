namespace Core.Shared
{
    public interface IHUDView
    {
        void SetScore(int score);
        void SetHealth(int current, int max);
    }
}