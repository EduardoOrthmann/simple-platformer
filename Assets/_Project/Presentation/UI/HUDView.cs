using _Project.Core.Shared;
using TMPro;
using UnityEngine;

namespace _Project.Presentation.UI
{
    public class HUDView : MonoBehaviour, IHUDView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        // ... other UI elements like a health slider

        public void SetScore(int score)
        {
            scoreText.text = $"Score: {score}";
        }

        public void SetHealth(int current, int max)
        {
            // Logic to update a health slider
        }
    }
}